namespace BookLib
{
    public class Book
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public int price { get; set; }

        public Book(int id, string title, int price)
        {
            Id = id;
            Title = title;
            this.price = price;
        }
        public Book()
        {

        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(price)}={price.ToString()}}}";
        }

    public void ValidateTitle()
        {
            if (Title == null)
            {
               throw new ArgumentNullException(nameof(Title));

            }
            if (Title.Length <3)
            {
                throw new ArgumentException(nameof(Title),"title missing letters");
            }

        }
    public void ValidatePrice()
        {
            if (price <0 )
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must not be  negative");
            }
            if(price >1200)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "price must not be over 1200"); 
            }
           
         }
    public void Validation()
        {
            ValidateTitle();    
            ValidatePrice();
        }
    }
}