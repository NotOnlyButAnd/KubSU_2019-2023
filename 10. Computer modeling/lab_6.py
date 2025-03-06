import numpy as np

class Processor:

    def __init__(self,ver,name):
        self.ver=ver
        self.time_work=0
        self.name=name
        self.enabled=0
        self.orders=0
        self.time_start=0
        self.zakaz=0
        self.mass_orders=0
        self.orders_koll=[]

    def connect_timeline(self,timeline):
        self.timeline=timeline

    def start_create_obr(self,time):
        if self.enabled==0:
            self.timeline.add_event({"name":self.name+" конец создания", "time":self.ver(time),"functions":[self.end_create_obr]})
            self.enabled=1
            self.time_start = time
            self.orders_koll[0]["time_queue"]=self.orders_koll[0]["time_queue"]+(self.timeline.time-self.orders_koll[0]["tec_time"])

    def end_create_obr(self,time):
        self.time_work =self.time_work+ (time-self.time_start)
        self.orders_koll[0]["time_work"] = self.orders_koll[0]["time_work"] + (time-self.time_start)
        self.enabled=0
        self.pop_orders(0)
        self.zakaz+=1
        if self.orders !=0:
            self.timeline.add_event({"name": self.name + " начало создания", "time": time, "functions": [self.start_create_obr]})

    def get_orders(self,time):
        self.orders+=1
        self.timeline.orders_all+=1
        tec_orders=self.timeline.tec_order.copy()
        tec_orders["path"]=tec_orders["path"]+"_"+self.name
        self.orders_koll.append(tec_orders)

    def pop_orders(self,time):
        self.orders-=1
        self.orders_koll[0]["tec_time"]=timeline.time
        self.timeline.tec_order=self.orders_koll.pop(0)

    def get_statistics(self):
        return self.name+"\n     время работы: "+str(self.time_work)+"\n     количество обработанных задач: "+str(self.zakaz)+"\n     количество заявок в очереди: "+str(self.orders)+"\n     коэффициент загрузки: "+str(round(self.time_work/self.timeline.time,2))+"\n     простой: "+str(round((self.timeline.time-self.time_work)/self.timeline.time,2)*100)+"%" + "\n <--------------------------------->"


class Timeline:
    def __init__(self,mass_proc):
        self.processors=mass_proc
        for i in self.processors:
            i.connect_timeline(self)
        self.enabled=0
        self.orders_all=0
        self.time=0
        self.zakaz=0
        self.history=[]
        self.order_history=[]
        self.tec_order={"path":"","time_queue":0,"time_work":0,"tec_time":self.time}
        self.events = [{"name": "заявка", "time": 0, "functions": [self.get_order,self.get_processors]}]
        self.time_work=0
        self.time_save_enable=0

    def add_event(self,el):
        self.events.append(el)
        self.events.sort(key=lambda x: x["time"])

    def get_order(self,time):
        new_time= self.time+np.random.normal(3,1)
        self.add_event({"name": "заявка", "time": new_time, "functions":[self.get_order,self.get_processors]})

    def get_processors(self,time):
        tec_proc = self.get_rand_processor()
        self.tec_order = {"path": "", "time_queue": 0, "time_work": 0, "tec_time": self.time}
        self.add_event({"name": tec_proc.name+" отослана заявка", "time": self.time,"functions": [tec_proc.get_orders]})
        if tec_proc.enabled==0:
            self.add_event({"name": tec_proc.name + " начало создания", "time": self.time, "functions": [tec_proc.start_create_obr]})

    def get_rand_processor(self):
       rd=np.random.rand()
       if rd >=0 and rd< 0.4:
           return self.processors[0]
       elif rd >=0.4 and rd< 0.7:
           return self.processors[1]
       else:
           return self.processors[2]

    def is_enabled(self):
        c=0
        for i in self.processors:
            if i.enabled ==1:
                c=1
        if c == 0 and self.enabled!=0:
            self.time_save_enable = self.time
        elif c==1 and self.enabled!=1:
            self.time_work = self.time_work + (self.time - self.time_save_enable)
        self.enabled=c

    def get_tik_simulator(self):
        tec_events = self.events.pop(0)
        self.time = tec_events["time"]
        if tec_events["name"]=="процессор1 конец создания":
            for i in tec_events["functions"]:
                i(self.time)
            rand_two=np.random.rand()
            if rand_two>=0 and rand_two<0.3 :
                self.add_event({"name":  self.processors[1].name+ "отослана заявка ","time":self.time,"functions":[self.processors[1].get_orders]})
                if self.processors[1].enabled == 0:
                    self.add_event({"name": self.processors[1].name + " начало создания", "time": self.time,"functions": [self.processors[1].start_create_obr]})
            else:
                self.add_event({"name": self.processors[2].name + "отослана заявка ", "time": self.time,"functions": [self.processors[2].get_orders]})
                if self.processors[2].enabled == 0:
                    self.add_event({"name": self.processors[2].name + "начало создания", "time": self.time,"functions": [self.processors[2].start_create_obr]})
        elif tec_events["name"]=="процессор2 конец создания" or tec_events["name"]=="процессор3 конец создания":
            for i in tec_events["functions"]:
                i(self.time)
            self.zakaz+=1
            self.order_history.append(self.tec_order)
        else:
            for i in tec_events["functions"]:
                i(self.time)
        self.history.append({"name":tec_events["name"],"time":tec_events["time"]})
        self.is_enabled()

    def get_history(self):
        str_rez=""
        for i in self.history:
            str_rez=str_rez+str(i)+"\n"
        return str_rez

    def get_statistic(self):
        str_rez = ""
        for i in self.processors:
            str_rez = str_rez + i. get_statistics() + "\n"
        str_rez = str_rez + "время: "+str(self.time)+"\nколичество выполненых задач: "+str(self.zakaz)+"\n" + "<---------------------------------> \n"
        mass_path=set()
        for i in self.order_history:
             mass_path.add(i["path"])
        for i in mass_path:
            mass_con_path=[]
            for j in self.order_history:
                if i==j["path"]:
                    mass_con_path.append(j)
            time_och=0
            time_work=0
            time_work_all=0
            for j in mass_con_path:
                time_och=time_och+j["time_queue"]
                time_work=time_work+j["time_work"]
            time_work_all=time_och+time_work
            kol = len(mass_con_path)
            str_rez = str_rez + "статистика заявок на данном пути: "+ i+"\n     Среднее время очереди: "+ str(time_och/kol)+"\n     Среднее время задачи: "+ str(time_work/kol)+ "\n     Колличество заявок: "+str(kol)+"\n     Процентное соотношение относительно всех заявок: "+str(round(kol/len(self.order_history)*100,0))+"%\n" + "<--------------------------------->\n"
        time_och = 0
        time_work = 0
        time_work_all = 0
        for i in self.order_history:
            time_och = time_och + i["time_queue"]
            time_work = time_work + i["time_work"]
        time_work_all = time_och + time_work
        kol = len(self.order_history)
        str_rez = str_rez + "Статистика по всем заявкам:" + "\n     Среднее время очереди: " + str(time_och / kol) + "\n    Среднее время задачи: " + str(time_work / kol) + "\n<--------------------------------->\n"
        str_rez = str_rez + "абсолютная пропускная способность: " + str(self.zakaz/self.time)+"\n<--------------------------------->\n"
        str_rez = str_rez + "относительная пропускная способность: " + str((self.zakaz / self.time)/(self.orders_all/self.time)) + "\n<--------------------------------->\n"
        str_rez = str_rez + "коэффициент загрузки всей программы: " + str(1-self.time_work/self.time) + "\n<--------------------------------->\n"
        return str_rez

    def get_orders_history(self):
        str_rez = ""
        for i in self.order_history:
            str_rez = str_rez + str(i) + "\n"
        return str_rez


processor1 = Processor(lambda x: np.random.normal(4, 1) + x, "процессор1")
processor2 = Processor(lambda x: np.random.normal(3, 1) + x, "процессор2")
processor3 = Processor(lambda x: np.random.normal(5, 2) + x, "процессор3")
processors = [processor1, processor2, processor3]
timeline = Timeline(processors)
while timeline.zakaz!=200:
    timeline.get_tik_simulator()
# print(timeline.get_history())
# print(timeline.get_orders_history())
print(timeline.get_statistic())

