
internal class LibraryApp
{
    private static void Main(string[] args)
    {
        // Inisialisasi objek katalog
        LibraryCatalog katalog = new LibraryCatalog();
        bool lanjut = true;
        while (lanjut) 
        {
            Console.WriteLine("===Program Buku===");
            Console.WriteLine("Pilih Menu:");
            Console.WriteLine("1. Tambah Buku");
            Console.WriteLine("2. Hapus Buku");
            Console.WriteLine("3. Pencarian Buku");
            Console.WriteLine("4. Daftar Buku");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilihan ");
            string pilih = Console.ReadLine();
            // Pilihan Menu
            switch (pilih)
            {
                case "1":
                    AddBook(katalog); // Memanggil method AddBook di dalam class LibraryApp
                    break;
                case "2":
                    RemoveBook(katalog); // Memanggil method RemoveBook di dalam class LibraryApp
                    break;
                case "3":
                    FindBook(katalog); // Memanggil method FindBook di dalam class LibraryApp
                    break;
                case "4":
                    ListBooks(katalog); // Memanggil method ListBooks di dalam class LibraryApp
                    break;
                case "5":
                    lanjut = false;
                    break;
                default:
                    ErrorHandler.Message("Pilihan tidak valid"); // jika salah menu
                    break;
            }
        }
    }
    // Menampilkan Menu Tambah Buku
    private static void AddBook(LibraryCatalog catalog)
    {
        Console.WriteLine("=== Menu Tambah Buku ===");
        Console.Write("Judul: ");
        string title = Console.ReadLine(); // input title
        Console.Write("Author: ");
        string author = Console.ReadLine(); // input author
        Console.Write("Tahun Publikasi: ");
        int publicationYear;
        // Cek jika publication year int atau bukan
        if (int.TryParse(Console.ReadLine(), out publicationYear))
        {
            // melakukan inisialisasi objek book
            Book book = new Book();
            book.Title = title; // memasukkan atribut Title denagn title
            book.Author = author; // memasukkan atribut Author denagn author
            book.PublicationYear = publicationYear; // memasukkan atribut PublicationYear denagn publicationYear
            catalog.AddBook(book);
        }
        else
        {
            // jika tahun publikasi huruf
            ErrorHandler.Message("Tahun publikasi harus berupa angka.");
        }
    }
    // Menampilkan Menu Hapus Buku
    private static void RemoveBook(LibraryCatalog catalog)
    {
        Console.WriteLine("=== Menu Hapus Buku ===");
        Console.Write("Hapus Buku berdasarkan judul: ");
        string title = Console.ReadLine();
        Book book = catalog.FindBook(title); // memanggil method FindBook pada objek catalog
        if (book != null) // jika ada maka (hapus book != tidak ada) => ada
        {
            catalog.RemoveBook(book);
            Console.WriteLine("Buku berhasil dihapus"); //error handling
        }
        else
        {
            ErrorHandler.Message("Buku tidak ada."); //error handling
        }
    }
    // Menampilkan Menu Pencarian Buku
    private static void FindBook(LibraryCatalog catalog)
    {
        Console.WriteLine("=== Menu Pencarian Buku ===");
        Console.Write("Judul Buku yang dicari: ");
        string title = Console.ReadLine();
        Book book = catalog.FindBook(title); // memanggil method FindBook pada objek catalog
        if (book != null)
        {
            Console.WriteLine("Buku tersedia");
            Console.WriteLine("Judul: " + book.Title + " Author: " + book.Author + " Tahun Publikasi: " + book.PublicationYear);
        }
        else
        {
            ErrorHandler.Message("Buku tidak ada."); //error handling
        }
    }
    // Menampilkan Menu Daftar Buku
    private static void ListBooks(LibraryCatalog catalog)
    {
        Console.WriteLine("=== Menu Daftar Buku ===");
        catalog.ListBooks();
    }
}
// Class untuk objek nanti dengan nama book
public class Book {
    public string Title {get; set; } //Title getter setter
    public string Author { get; set; } //Author getter setter
    public int PublicationYear { get; set; } //PublicationYear getter setter
}

public class LibraryCatalog
{
    private List<Book> books;
    // Contructor untuk inisialiasi books
    public LibraryCatalog()
    {
        books = new List<Book>();
    }
    // Method tambah buku
    public void AddBook(Book book)
    {
        books.Add(book); // memanfaatkan method Add pada List => menambahkan ke list
        Console.WriteLine("Buku Berhasil ditambahkan");
    }
    // Method hapus buku
    public void RemoveBook(Book book)
    {
        books.Remove(book); // memanfaatkan method Remove pada List => menghapus dari list
    }
    // Method Mnecari buku
    public Book FindBook(string title)
    {   // melooping books
        foreach (Book book in books)
        {   // Mnecari berdasarkan judul jika sama kelur return
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                return book;
            }
        }
        return null;
    }
    // Method daftar buku
    public void ListBooks() 
    {
        Console.WriteLine("Dafar Buku yang Diinput : ");
        // melooping books
        foreach (Book book in books)
        {
            Console.WriteLine(" - Judul: "+book.Title +" Author: "+ book.Author + " Tahun Publikasi: "+book.PublicationYear);
        }
    }
}
// Class untuk error handling
class ErrorHandler {
    //ErroHandler.Message() => method untuk menampilkan pesan error
    public static void Message(string message) 
    {
        Console.WriteLine("Error : " + message);
    }
}