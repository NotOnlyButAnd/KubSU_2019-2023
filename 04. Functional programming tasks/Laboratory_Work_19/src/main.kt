fun addElement(arr: Array<Product>, element: Product): Array<Product> {
    val mutableArray = arr.toMutableList()
    mutableArray.add(element)
    return mutableArray.toTypedArray()
}

//запросы
//самый продаваемый товар в данном магазине
fun select1(shop: Shop, maxS: Int, name: String, realizations: Array<Realization>, products: Array<Product>): String{
    var maxName: String = name
    var max = maxS
    shop.realizationsId.forEach{
        val cur = shop.getRealization(0, it, realizations)
        //println("${cur.count} ${max}")
        if (cur.count > max){
            //select1(shop, cur.count, cur.getProduct(0, cur.productId, products).name, realizations, products)
                max = cur.count
            maxName = cur.getProduct(0, cur.productId, products).name
        }
    }
    return maxName
}

fun select1cool(shop: Shop, realizations: Array<Realization>, products: Array<Product>) =
    select1(shop, 0, "Undefinded", realizations, products)

//средняя зп по каждому магазину
fun select2(shops: Array<Shop>, employees: Array<Employee>): String{
    var answer: String = ""
    shops.forEach {
        val curShop = it
        val count = curShop.employeesId.size
        var midSalary = 0
        it.employeesId.forEach {
            midSalary += curShop.getEmployee(0, it, employees).salary
        }
        answer += "Средняя зп в магазине по адресу ${curShop.address}: ${midSalary/count}\n"
    }
    return answer
}

//продукты содержащие воду
fun select3(products: Array<Product>): String{
    var answer: String = ""
    products.forEach {
        if (it.structure.contains("Вода", true))
            answer += it.name + "; "
    }
    return answer
}

//магазины в которых есть Молоко
fun select4(shops: Array<Shop>, products: Array<Product>): String{
    var answer: String = ""
    shops.forEach {
        val curShop = it
        it.productsId.forEach {
            if (curShop.getProduct(0, it, products).name == "Молоко")
                answer += "\n" + curShop.address
        }
    }
    return answer
}

//самый дорогой продукт в каждом магазине
fun select5(shops: Array<Shop>, products: Array<Product>): String{
    var answer: String = ""
    shops.forEach {
        val curShop = it
        var maxName = ""
        var maxCost = 0
        it.productsId.forEach {
            val curProd = curShop.getProduct(0, it, products)
            if (curProd.cost > maxCost){
                maxCost = curProd.cost
                maxName = curProd.name
            }
        }
        answer += "\n${curShop.address}: $maxName (цена: $maxCost)"
    }
    return answer
}

fun main() {


    val pathToJSONProducts : String = "src/product.json"
    val pathToJSONEmployees : String = "src/employee.json"
    val pathToJSONRealizations : String = "src/realization.json"
    val pathToJSONShops : String = "src/shop.json"

    var prodsFromJSON : Array<Product> = Product.readfromJSON(pathToJSONProducts)
    println("------------------\nProducts\n------------------")
    prodsFromJSON.forEach {
        it.printInfo()
    }


    // Добавление продукта в массив продуктов
    /*
    val product1 : Product = Product(3, "Popa", 100, 1, 0, "Left ass-half; Right ass-half", "2030-01-01")
    prodsFromJSON = addElement(prodsFromJSON, product1)
    */

    var employeesFromJSON : Array<Employee> = Employee.readfromJSON(pathToJSONEmployees)
    println("-----------------\nEmployees\n------------------")
    employeesFromJSON.forEach {
        it.printInfo()
    }


    var realizationsFromJSON : Array<Realization> = Realization.readfromJSON(pathToJSONRealizations)
    println("----------------\nRealizations\n----------------")
    realizationsFromJSON.forEach {
        it.printInfo()
    }


    var shopsFromJSON : Array<Shop> = Shop.readfromJSON(pathToJSONShops)
    println("-------------------\nShops\n-------------------")
    shopsFromJSON.forEach {
        it.printInfo()
    }

    //println(realizationsFromJSON[2].getProduct(0, realizationsFromJSON[2].productId, prodsFromJSON).name)


    //select1
    print("\nСамый продаваемый товар в 1 магазине: ")
    println(select1cool(shopsFromJSON[0], realizationsFromJSON, prodsFromJSON))

    print("Самый продаваемый товар в 2 магазине: ")
    println(select1cool(shopsFromJSON[1], realizationsFromJSON, prodsFromJSON))
    println()

    println(select2(shopsFromJSON, employeesFromJSON))

    println("\nПродукты содержащие воду: ${select3(prodsFromJSON)}")


    println("\nМагазины в которых есть молоко: ${select4(shopsFromJSON, prodsFromJSON)}")


    println("\nСамые дорогие продукты в каждом магазине: ${select5(shopsFromJSON, prodsFromJSON)}")


    // Запись продуктов в JSON
    //Product.writeToJSON(pathToJSONProducts, prodsFromJSON)

    //var prodList : Products = Products()

    /*
    prodList.readfromJSON(pathToJSONProducts)
    prodList.productList.forEach{
        it.printInfo()
    }
    */


    /*
    val product1 : Product = Product(1, "Popa", 100, 1, 0, "Left ass-half; Right ass-half", "2030-01-01")
    product1.printInfo()

    product1.cost = 200

    product1.printInfo()

    val product2 : Product = Product(2, "Siski", 300, 3, 1, "Left boob; Right boob", "2030-01-01")
    product2.printInfo()

    val employee1 : Employee = Employee(1, "Продавец", 10000, "Минин", "Кирилл", "Сергеевич")
    employee1.printInfo()



    val shop1 : Shop = Shop(1, "ул. Российская, д. 71/1")
    shop1.products.add(product1)
    shop1.products.add(product2)
    shop1.printProductsInfo()

    val realization1:Realization = Realization(1,product1,1, shop1)
    realization1.printInfo()
     */

    //val product1 : Product = Product(1, "Popa", 100, 1, 0, "Left ass-half; Right ass-half", "2030-01-01")


    // Простой пример чтения из многострочной строки в объект класса Products
    /*
    val jsonStr = """
    {
        "id": 1,
        "name": "Яблоко",
        "cost": 35,
        "count": 1000,
        "countSold": 0,
        "structure": "Undefinded",
        "expirationDate": "2022-01-01"
    }
    """.trimIndent()

    val product2: Product = Gson().fromJson<Product>(jsonStr, Product::class.java)
    product2.printInfo()
     */

}

