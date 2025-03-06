import com.google.gson.Gson
import java.io.BufferedReader
import java.io.File
import java.time.LocalDate

class Product(val id : Int, val name : String, var cost : Int, var count : Int, var countSold : Int, val structure : String, val expirationDate : String) {

    fun printInfo() : Unit{
        println("ID: $id;\nName: $name;\nCost: $cost;\nCount: $count;\nCount sold: $countSold;\n" +
                "Structure: $structure;\nExpiration date: $expirationDate;\n")
    }

    companion object{
        fun readfromJSON(f:String) : Array<Product> {
            //Creating a new Gson object to read data
            var gson = Gson()
            //Read the PostJSON.json file
            val bufferedReader: BufferedReader = File(f).bufferedReader()
            // Read the text from bufferReader and store in String variable
            val inputString = bufferedReader.use { it.readText() }

            //Convert the Json File to Gson Object
            var products = gson.fromJson(inputString, Array<Product>::class.java)

            return products
        }

        fun writeToJSON (path: String, productsList: Array<Product>) {
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