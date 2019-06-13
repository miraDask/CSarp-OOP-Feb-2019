namespace StorageMester.Tests.BusinessLogic
{
    using NUnit.Framework;
    using StorageMaster.Core;
    using StorageMaster.Entities.Products;
    using StorageMaster.Entities.Storage;
    using StorageMaster.Entities.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class StorageMasterTests
    {
        private StorageMaster storageMaster;

        [SetUp]
        public void SetUp()
        {
            this.storageMaster = new StorageMaster();
        }

        [TearDown]
        public void TearDown()
        {
            this.storageMaster = null;
        }

        [Test]
        public void AddProduct_AddsNewTypeOfProduct_ToProductsCollection()
        {
            this.storageMaster.AddProduct("HardDrive", 100);

            var productsPool = GetProductsCollection();
            var addedProduct = productsPool["HardDrive"].Peek();

            Assert.IsInstanceOf(typeof(HardDrive), addedProduct
                , "Object is not of expected type!");
        }

        [Test]
        public void AddProduct_AddsExistingTypeOfProguct()
        {
            this.storageMaster.AddProduct("HardDrive", 100);
            this.storageMaster.AddProduct("HardDrive", 100);
            var productsPool = GetProductsCollection();
            var expectedProductsCount = 2;

            Assert.AreEqual(expectedProductsCount, productsPool["HardDrive"].Count
              , "Count of current products collection is not the same as expected count!");
        }

        [Test]
        public void AddProduct_ReturnsCorrectMessage()
        {
            var addNewProductMessage = this.storageMaster.AddProduct("HardDrive", 100);

            var expectedMessage = "Added HardDrive to pool";

            Assert.AreEqual(expectedMessage, addNewProductMessage
                , "Message for adding new product is not the same as expected message!");
        }

        [Test]
        public void RegisterStorage_Correctly()
        {
            this.storageMaster.RegisterStorage(type: "Warehouse", name: "CurrentStorage");

            var storageRegistry = GetStorageCollection();
            var registeredStorage = storageRegistry["CurrentStorage"];

            Assert.IsInstanceOf(typeof(Warehouse), registeredStorage
                , "Registered storage is not of expected type!");
        }

        [Test]
        public void RegisterStorage_ReturnsCorrectMessage()
        {
            var messageForRegisteredStorage =
                this.storageMaster.RegisterStorage(type:"Warehouse", name: "CurrentStorage");

            var expectedMessage = "Registered CurrentStorage";

            Assert.AreEqual(expectedMessage, messageForRegisteredStorage
                 , "Message for register new storage is not the same as expected message!");
        }
        
        [Test]
        public void SelectVehicle_Sets_CorrectVehicle()
        {
            this.storageMaster.RegisterStorage(type: "Warehouse", name: "CurrentStorage");
            this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 0);

            var currentVehicle = GetCurrentVehicle();

            Assert.IsInstanceOf(typeof(Semi), currentVehicle
                , "Selected vehicle is not of expected type!");
        }

        [Test]
        public void SelectVehicle_ReturnsCorrectMessage()
        {
            this.storageMaster.RegisterStorage(type: "Warehouse", name: "CurrentStorage");

            var selectedCarMessage =
                this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 0);
            var expectedMessage = "Selected Semi";

            Assert.AreEqual(expectedMessage, selectedCarMessage
                 , "Message for selecting vehicle is not the same as expected message!");
        }

        [Test]
        public void LoadVehicle_RemovesExistingProduct_FromProductsCollection()
        {
            this.storageMaster.RegisterStorage(type: "Warehouse", name: "CurrentStorage");
            this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 1);

            var productType = "Ram";
            this.storageMaster.AddProduct(productType, price: 100);

            this.storageMaster.LoadVehicle(new List<string> { productType });
            var productsPool = GetProductsCollection();

            var countOfCurrentProductInProductsCollection = productsPool[productType].Count;
            var expectedCountOfCurrentProductInProductsCollection = 0;

            Assert.AreEqual(expectedCountOfCurrentProductInProductsCollection
                , countOfCurrentProductInProductsCollection
                , "Current product is not removed from products collection!");
        }

        // this test also tests that LoadVehicle counts correctly loaded products
        [Test]
        public void LoadVehicle_ReturnsCorrectMessage()
        {
            this.storageMaster.RegisterStorage(type: "Warehouse", name: "CurrentStorage");
            this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 0);

            var productType = "HardDrive";

            // count of products more then Vehicle Capacity ;  Semi capacity == 10;
            var countOfProducts = 15;
            for (int i = 1; i <= countOfProducts; i++)
            {
                this.storageMaster.AddProduct(productType, price: 100);
            }

            var productsForLoading = new List<string>();
            for (int i = 1; i <= countOfProducts; i++)
            {
                productsForLoading.Add(productType);
            }

            var message = this.storageMaster.LoadVehicle(productsForLoading);

            var expectedMessage = "Loaded 10/15 products into Semi";

            Assert.AreEqual(expectedMessage, message
                , "Message for loaded products is not the same as expected!");
        }

        [Test]
        public void LoadVehicle_ThrowsInvalidOperationException_WhenProductOfThisType_AreOutOfStock()
        {
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "CurrentStorage");
            this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 0);

            var productType = "Ram";
            this.storageMaster.AddProduct(productType, price: 100);
            var productsToLoad = new List<string>() { productType };

            this.storageMaster.LoadVehicle(productsToLoad);

            Assert.Throws<InvalidOperationException>(()
               => this.storageMaster.LoadVehicle(productsToLoad)
               , "This type of product is not out of stock!");
        }

        [Test]
        public void LoadVehicle_ThrowsInvalidOperationException_WhenProductType_DoesNotExistInTheProductCollection()
        {
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "CurrentStorage");
            this.storageMaster.SelectVehicle(storageName: "CurrentStorage", garageSlot: 1);

            string productType = "Desktop";

            Assert.Throws<InvalidOperationException>(()
                => this.storageMaster.LoadVehicle(new List<string> { productType })
                , "This type of product exists in the product collection!");
        }

        [Test]
        public void SendVehicleTo_ThrowsInvalidOperationException_WhenSendsVehicle_To_InvalidStorage()
        {
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "SuorceStorage");
            var destinationStorage = "Warehouse";

            Assert.Throws<InvalidOperationException>(()
                => this.storageMaster.SendVehicleTo("CurrentStorage", 0 , destinationStorage)
                ,"Destination storage exists!");
        }

        [Test]
        public void SendVehicleTo_ThrowsInvalidOperationException_WhenSendsVehicle_From_InvalidStorage()
        {
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "DestinationStorage");
            var suorceStorage = "Warehouse";

            Assert.Throws<InvalidOperationException>(()
                => this.storageMaster.SendVehicleTo(suorceStorage, 0, "CurrentStorage")
                , "Suorce storage exists!");
        }

        [Test]
        public void SendVehicleTo_Returns_CorrectMessage_WhenSuccessfullySendsVehicle()
        {
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "SuorceStorage");
            this.storageMaster.RegisterStorage(type: "AutomatedWarehouse", name: "DestinationStorage");
            
            var actualMessage = this.storageMaster.SendVehicleTo("SuorceStorage", 0, "DestinationStorage");
            var expectedMessage =
                "Sent Van to DestinationStorage (slot 1)";

            Assert.AreEqual(expectedMessage, actualMessage
                , "Message for successfully sended vehicle is not the same as expected message!");
        }

        [Test]
        public void UnloadVehicle_Returns_CorrectMessage()
        {
            this.storageMaster.RegisterStorage(type: "AutomatedWarehouse", name: "CurrentStorage");

            var actualMessage = this.storageMaster.UnloadVehicle("CurrentStorage", 0);
            var expectedMessage =
                "Unloaded 0/0 products at CurrentStorage";

            Assert.AreEqual(expectedMessage, actualMessage,
                "Message for successfully unloaded vehicle is not the same as expected message!");
        }

        [Test]
        public void GetStorageStatus_Returns_CorrectStatus()
        {

            this.storageMaster.RegisterStorage(type: "AutomatedWarehouse", name: "SuorceStorage");
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "DestinationStorage");
            this.storageMaster.SelectVehicle(storageName: "SuorceStorage", garageSlot: 0);

            var firstProduct = "Ram";
            var secondProduct = "Gpu";

            this.storageMaster.AddProduct(firstProduct, price: 100);
            this.storageMaster.AddProduct(secondProduct, price: 89);

            this.storageMaster.LoadVehicle(new List<string> { firstProduct, secondProduct});
            this.storageMaster.SendVehicleTo("SuorceStorage", 0, "DestinationStorage");
            this.storageMaster.UnloadVehicle("DestinationStorage", 3);

            var actualStatus = this.storageMaster.GetStorageStatus("DestinationStorage");

            var expectedStatus =
                "Stock (0.8/2): [Gpu (1), Ram (1)]"
                + Environment.NewLine
                + "Garage: [Van|Van|Van|Truck|empty]";

            Assert.AreEqual(expectedStatus, actualStatus
                ,"Status info is not the same as expected info!");
        }

        [Test]
        public void GetSummary_Returns_CorrectSummary()
        {
            this.storageMaster.RegisterStorage(type: "AutomatedWarehouse", name: "SuorceStorage");
            this.storageMaster.RegisterStorage(type: "DistributionCenter", name: "DestinationStorage");
            this.storageMaster.SelectVehicle(storageName: "SuorceStorage", garageSlot: 0);

            var firstProduct = "Ram";
            var secondProduct = "Gpu";

            this.storageMaster.AddProduct(firstProduct, price: 100);
            this.storageMaster.AddProduct(secondProduct, price: 89);

            this.storageMaster.LoadVehicle(new List<string> { firstProduct, secondProduct });
            this.storageMaster.SendVehicleTo("SuorceStorage", 0, "DestinationStorage");
            this.storageMaster.UnloadVehicle("DestinationStorage", 3);

            var actualSummary = this.storageMaster.GetSummary();
            var expectedSummary =
                "DestinationStorage:"
                + Environment.NewLine
                + "Storage worth: $189.00"
                +Environment.NewLine
                + "SuorceStorage:"
                + Environment.NewLine
                + "Storage worth: $0.00";

            Assert.AreEqual(expectedSummary, actualSummary
                ,"Status info is not the same as expected info!");
        }

        private Vehicle GetCurrentVehicle()
        {
            var type = typeof(StorageMaster);
            var currentVehicle = (Vehicle)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "currentVehicle")
                .GetValue(this.storageMaster);

            return currentVehicle;
        }

        private Dictionary<string, Storage> GetStorageCollection()
        {
            var type = typeof(StorageMaster);
            var storageRegistry = (Dictionary<string, Storage>)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "storageRegistry")
                .GetValue(this.storageMaster);

            return storageRegistry;
        }

        private Dictionary<string, Stack<Product>> GetProductsCollection()
        {
            var type = typeof(StorageMaster);
            var productsPool = (Dictionary<string, Stack<Product>>)type
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(x => x.Name == "productsPool")
                .GetValue(this.storageMaster);

            return productsPool;
        }
    }
}
