using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private const int InitialSize = 4;

        private IProduct[] products;

        public ProductStock()
        {
            this.products = new IProduct[InitialSize];
        }

        public IProduct this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.products[index];
            }
            set
            {
                if (index < 0 || index > this.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                this.products[index] = value;
            }

        }

        public int Count { get; private set; }

        public int Capacity => this.products.Length;

        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Cannot add null");
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.products[i] == product)
                {
                    this.products[i].Quantity += product.Quantity;
                    return;
                }
            }

            if (this.products.Length == this.Count)
            {
                Resize();
            }

            this.products[this.Count] = product;
            this.Count++;
        }

        public bool Remove(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Cannot remove invalid product");
            }

            var isInCollection = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.products[i] == product)
                {
                    isInCollection = true;
                    int index = i;
                    this.ShiftLeft(index);
                    break;
                }
            }

            this.Count--;

            if (this.Count * 2 <= this.Capacity)
            {
                this.ShrinkArray();
            }

            return isInCollection;
        }

        public bool Contains(IProduct product)
        {
            var isPresent = false;

            if (product == null)
            {
                throw new ArgumentNullException("Cannot add null");
            }

            foreach (var currentProduct in this.products)
            {
                if (currentProduct == product)
                {
                    isPresent = true;
                    break;
                }
            }

            return isPresent;
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }

            return this.products[index];
        }

        public IProduct FindByLabel(string label)
        {

            if (string.IsNullOrEmpty(label) || string.IsNullOrWhiteSpace(label))
            {
                throw new ArgumentException("Label cannot be empty");
            }

            IProduct product = null;

            foreach (var currentProduct in this.products)
            {
                if (currentProduct != null && currentProduct.Label == label )
                {
                    product = currentProduct;
                    break;
                }
            }

            if (product == null)
            {
                throw new ArgumentException("There is no product with this label in stock");
            }

            return product;
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("There are no products in stock");
            }

            IProduct mostExpensiveProduct = this.products[0];

            for (int i = 1; i < this.Count; i++)
            {
                var currentProduct = this.products[i];

                if (currentProduct.Price > mostExpensiveProduct.Price)
                {
                    mostExpensiveProduct = currentProduct;
                }
            }

            return mostExpensiveProduct;
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            if (price < 0)
            {
                throw new InvalidOperationException("Price cannot be negative");
            }

            var productsWithSamePriceAsPassedPrice = new List<IProduct>();

            foreach (var product in this.products)
            {
                if (product != null && product.Price == (decimal)price)
                {
                    productsWithSamePriceAsPassedPrice.Add(product);
                }
            }

            return productsWithSamePriceAsPassedPrice;
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new InvalidOperationException("Quantity cannot be negative");
            }

            var productsWithSameQuantityAsPassedQuantity = new List<IProduct>();

            foreach (var product in this.products)
            {
                if (product != null && product.Quantity == quantity)
                {
                    productsWithSameQuantityAsPassedQuantity.Add(product);
                }
            }

            return productsWithSameQuantityAsPassedQuantity;
        }

        public IEnumerable<IProduct> FindAllInRange(double low, double hi)
        {
            if (low < 0 || hi < 0)
            {
                throw new InvalidOperationException("Price cannot be negative");
            }

            var productsWithPriceInPassedRange = new List<IProduct>();

            foreach (var product in this.products)
            {
                if (product != null 
                    && product.Price >= (decimal)low 
                    && product.Price <= (decimal)hi)
                {
                    productsWithPriceInPassedRange.Add(product);
                }
            }

            return productsWithPriceInPassedRange.OrderByDescending(x => x.Price);
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            foreach (var product in this.products)
            {
                yield return product;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            var newLength = this.products.Length * 2;
            var tempArray = new IProduct[newLength];

            for (int i = 0; i < products.Length; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }

        private void ShrinkArray()
        {
            var tempArray = new IProduct[this.Capacity / 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.products[i];
            }

            this.products = tempArray;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.products[i] = this.products[i + 1];
            }

            this.products[this.Count - 1] = null;
        }
    }
}
