using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Book book = new Book("Title", "Author", "Format", "FilePath");
        book.Open();
    }
}

// Book class representing a single eBook
public class Book
{
	private string title;
	private string author;
	private string format;
	private string filePath;
	public Book(string title, string author, string format, string filePath)
	{
		this.title = title;
		this.author = author;
		this.format = format;
		this.filePath = filePath;
	}

	public string Title
	{
		get
		{
			return title;
		}
	}

	public string Author
	{
		get
		{
			return author;
		}
	}

	public void Open()
	{
		// Code to open the book
		Console.WriteLine("Opening book: " + title);
	}

	public void Close()
	{
		// Code to close the book
		Console.WriteLine("Closing book: " + title);
	}

	public List<int> Search(string query)
	{
		// Code to search within the book and return matching page numbers
		Console.WriteLine("Searching for '" + query + "' in book: " + title);
		return new List<int>();
	}
}

// BookSettings class managing the settings for a single book
public class BookSettings
{
	protected int fontSize;
	protected string fontType;
	protected string bgColor;
	public BookSettings(int fontSize, string fontType, string bgColor)
	{
		this.fontSize = fontSize;
		this.fontType = fontType;
		this.bgColor = bgColor;
	}

	public int FontSize
	{
		get
		{
			return fontSize;
		}
	}

	public string BgColor
	{
		get
		{
			return bgColor;
		}

		set
		{
			bgColor = value;
		}
	}
}

// FontSettings class for managing font settings
class FontSettings : BookSettings
{
	public FontSettings(int fontSize, string fontType, string bgColor) : base(fontSize, fontType, bgColor)
	{
	}

	public string FontType
	{
		get
		{
			return fontType;
		}

		set
		{
			fontType = value;
		}
	}
}

// ColorSettings class for managing background color settings
class ColorSettings : BookSettings
{
	public ColorSettings(int fontSize, string fontType, string bgColor) : base(fontSize, fontType, bgColor)
	{
	}
}

// Bookmark class representing a single user bookmark within a book
class Bookmark
{
	private int pageNumber;
	private string description;
	public Bookmark(int pageNumber, string description)
	{
		this.pageNumber = pageNumber;
		this.description = description;
	}

	public void Create()
	{
		// Code to create a new bookmark
		Console.WriteLine("Creating bookmark: " + description);
	}

	public void Edit(string newDescription)
	{
		// Code to edit an existing bookmark
		Console.WriteLine("Editing bookmark: " + description + " -> " + newDescription);
		description = newDescription;
	}

	public void Delete()
	{
		// Code to delete an existing bookmark
		Console.WriteLine("Deleting bookmark: " + description);
	}
}

// Note class representing a single user note within a book
class Note
{
	private int pageNumber;
	private string text;
	public Note(int pageNumber, string text)
	{
		this.pageNumber = pageNumber;
		this.text = text;
	}

	public void Create()
	{
		// Code to create a new note
		Console.WriteLine("Creating note: " + text);
	}

	public void Edit(string newText)
	{
		// Code to edit an existing note
		Console.WriteLine("Editing note: " + text + " -> " + newText);
	}
}