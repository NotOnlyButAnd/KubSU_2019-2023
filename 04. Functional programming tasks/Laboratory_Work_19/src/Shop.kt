import com.google.gson.Gson
import java.io.BufferedReader
import java.io.File

class Shop (val id : Int, var address : String){
    var productsId : MutableList<Int> = mutableListOf()
    var employeesId : MutableList<Int> = mutableListOf()
    var realizationsId : MutableList<Int> = mutableListOf()

    fun getProduct (counter: Int, id: Int, products: Array<Product>): Product =
        if (counter != products.size)
        {
            if(products[counter].id == id)
                products[counter]
            else
                getProduct(counter+1, id, products)
        }
        else
            throw IllegalArgumentException("Try again")

    fun getEmployee (counter: Int, id: Int, employees: Array<Employee>): Employee =
        if (counter != employees.size)
        {
            if(employees[counter].id == id)
                employees[counter]
            else
                getEmployee(counter+1, id, employees)
        }
        else
            throw IllegalArgumentException("Try again")

    fun getRealization (counter: Int, id: Int, realizations: Array<Realization>): Realization =
        if (counter != realizations.size)
        {
            if(realizations[counter].id == id)
                realizations[counter]
            else
                getRealization(counter+1, id, realizations)
        }
        else
            throw IllegalArgumentException("Try again")


    fun printProductsId () : Unit{
        println("Products of shop $id:")
        productsId.forEach{
            println(it)
        }
    }

    fun printEmployeesId () : Unit{
        println("Employees of shop $id:")
        employeesId.forEach{
            println(it)
        }
    }

    fun printRealizationsId () : Unit{
        println("Realizations of shop $id:")
        realizationsId.forEach{
            println(it)
        }
    }

    fun printInfo() : Unit{
        println("\nId of shop: $id")
        println("Address: $address")
        printProductsId()
        printEmployeesId()
        printRealizationsId()
    }

    companion object{
        fun readfromJSON(f:String) : Array<Shop> {
            //Creating a new Gson object to read data
            var gson = Gson()
            //Read the PostJSON.json file
            val bufferedReader: BufferedReader = File(f).bufferedReader()
            // Read the text from bufferReader and store in String variable
            val inputString = bufferedReader.use { it.readText() }

            //Convert the Json File to Gson Object
            var products = gson.fromJson(inputString, Array<Shop>::class.java)

            return products
            /*
            products.forEach{
                it.printInfo()
            }
             */

            // Всякие красивые выводы
            /*
            println(products.productList.size)
            products.productList.forEach{
                it.printInfo()
            }
            //Initialize the String Builder

            var stringBuilder = StringBuilder("Product Details\n---------------------")
            stringBuilder?.append("\nProduct id: " + product.id)
            stringBuilder?.append("\nProduct name: " + product.name)
            stringBuilder?.append("\nProduct cost: " + product.cost)
            stringBuilder?.append("\nCount:" + product.count)
            stringBuilder?.append("\nCount sold:" + product.countSold)
            stringBuilder?.append("\nStructure:" + product.structure)
            stringBuilder?.append("\nExpiration date:" + product.expirationDate)

            // прочесть массив данных

            stringBuilder? .append ("\ nTags:")
            //get the all Tags
            product.postTag?.forEach { tag -> stringBuilder?.append(tag + ",") }

            //Display the all Json object in text View
            println(stringBuilder.toString())
            */
        }

        fun writeToJSON (path: String, productsList: Array<Shop>) {
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