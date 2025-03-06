import com.google.gson.Gson
import java.io.BufferedReader
import java.io.File

class Employee (val id : Int, var post : String, var salary : Int, var surname : String, var firstname : String, var lastname : String) {

    fun printInfo() : Unit{
        println("ID: $id;\nSurname: $surname;\nFirstname: $firstname;\nLastname: $lastname;\nPost: $post;\nSalary: $salary;\n")
    }

    companion object{
        fun readfromJSON(f:String) : Array<Employee> {
            //Creating a new Gson object to read data
            var gson = Gson()
            //Read the PostJSON.json file
            val bufferedReader: BufferedReader = File(f).bufferedReader()
            // Read the text from bufferReader and store in String variable
            val inputString = bufferedReader.use { it.readText() }

            //Convert the Json File to Gson Object
            var products = gson.fromJson(inputString, Array<Employee>::class.java)

            return products
        }

        fun writeToJSON (path: String, productsList: Array<Employee>) {
            // Создание объекта Gson
            var gson = Gson ()
            // Преобразование Json объект в JsonString
            var jsonString: String = gson.toJson (productsList)
            // Инициализируем средство записи файлов и записываем в файл
            val file = File (path)
            file.writeText (jsonString)
        }

    }

}