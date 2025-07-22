using System;
using System.Collections.Generic;
using System.Linq;

//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>()
{
    new Product()
    {
        Name = "Whistling Wand",
        Price = 19.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Love Sonnets Collection",
        Price = 12.50M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Golden Trumpet",
        Price = 299.99M,
        ProductTypeId = 2
    },
    new Product()
    {
        Name = "Modern Poetry Anthology",
        Price = 18.75M,
        ProductTypeId = 1
    },
    new Product()
    {
        Name = "Silver Trombone",
        Price = 450.00M,
        ProductTypeId = 2
    }
};

//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>()
{
    new ProductType() { Id = 1, Title = "Poem" },
    new ProductType() { Id = 2, Title = "Brass" },
};

//put your greeting here
string greeting = "Welcome to Brass & Poem";
Console.WriteLine(greeting);

//implement your loop here
string choice = null;
while (choice != "5")
{
    DisplayMenu();
    choice = Console.ReadLine();
    
    if (choice == "1")
    {
        DisplayAllProducts(products, productTypes);
    }
    else if (choice == "2")
    {
        DeleteProduct(products, productTypes);
    }
    else if (choice == "3")
    {
        AddProduct(products, productTypes);
    }
    else if (choice == "4")
    {
        UpdateProduct(products, productTypes);
    }
    else if (choice == "5")
    {
        Console.WriteLine("Goodbye!");
    }
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
    {
        Product product = products[i];
        ProductType productType = productTypes.FirstOrDefault(pt => pt.Id == product.ProductTypeId);
        Console.WriteLine($"{i + 1}. {product.Name} - ${product.Price} - {productType?.Title}");
    }
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Please enter the number of the product you'd like to delete:");
    
    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= products.Count)
    {
        products.RemoveAt(choice - 1);
        Console.WriteLine("Product deleted successfully.");
    }
    else
    {
        Console.WriteLine("Invalid selection.");
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    Console.WriteLine("Please enter the name of the new product:");
    string name = Console.ReadLine();
    
    Console.WriteLine("Please enter the price of the new product:");
    if (decimal.TryParse(Console.ReadLine(), out decimal price))
    {
        // Display product types
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }
        
        Console.WriteLine("Please choose a product type:");
        if (int.TryParse(Console.ReadLine(), out int typeChoice) && typeChoice >= 1 && typeChoice <= productTypes.Count)
        {
            Product newProduct = new Product()
            {
                Name = name,
                Price = price,
                ProductTypeId = productTypes[typeChoice - 1].Id
            };
            
            products.Add(newProduct);
            Console.WriteLine("Product added successfully.");
        }
        else
        {
            Console.WriteLine("Invalid product type selection.");
        }
    }
    else
    {
        Console.WriteLine("Invalid price format.");
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    DisplayAllProducts(products, productTypes);
    Console.WriteLine("Please enter the number of the product you'd like to update:");
    
    if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= products.Count)
    {
        Product productToUpdate = products[choice - 1];
        
        Console.WriteLine("Please enter the updated name (or press Enter to keep current):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
        {
            productToUpdate.Name = newName;
        }
        
        Console.WriteLine("Please enter the updated price (or press Enter to keep current):");
        string priceInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(priceInput) && decimal.TryParse(priceInput, out decimal newPrice))
        {
            productToUpdate.Price = newPrice;
        }
        
        // Display product types
        for (int i = 0; i < productTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {productTypes[i].Title}");
        }
        
        Console.WriteLine("Please choose the updated product type (or press Enter to keep current):");
        string typeInput = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(typeInput) && int.TryParse(typeInput, out int newTypeChoice) && 
            newTypeChoice >= 1 && newTypeChoice <= productTypes.Count)
        {
            productToUpdate.ProductTypeId = productTypes[newTypeChoice - 1].Id;
        }
        
        Console.WriteLine("Product updated successfully.");
    }
    else
    {
        Console.WriteLine("Invalid selection.");
    }
}

// don't move or change this!
public partial class Program { }
