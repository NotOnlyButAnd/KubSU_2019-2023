import com.google.gson.Gson
import java.io.BufferedReader
import java.io.File

class Realization (val id : Int, val productId: Int, var count : Int, val shopId : Int) {

    fun printInfo() : Unit{
        println("ID: $id;\nProduct: $productId;\nCount: $count;\nShop: $shopId;\n")
    }


    fun getProduct(counter: Int, id: Int, products: Array<Product>): Product =
        if (counter != products.size)
        {
            if(products[counter].id == id)
                products[counter]
            else
                getProduct(counter+1, id, products)
        }
        else
            throw IllegalArgumentException("Try again")

    companion object{
        fun readfromJSON(f:String) : Array<Realization> {
            //Creating a new Gson object to read data
            var gson = Gson()
            //Read the PostJSON.json file
            val bufferedReader: BufferedReader = File(f).bufferedReader()
            // Read the text from bufferReader and store in String variable
            val inputString = bufferedReader.use { it.readText() }

            //Convert the Json File to Gson Object
            var products = gson.fromJson(inputString, Array<Realization>::class.java)

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

        fun writeToJSON (path: String, productsList: Array<Realization>) {
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