using System;

public class Program
{
    // Document interface
    public interface IDocument
    {
        void Open();
    }

    // WordDocument class
    public class WordDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Word Document");
        }
    }

    // PdfDocument class
    public class PdfDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening PDF Document");
        }
    }

    // ExcelDocument class
    public class ExcelDocument : IDocument
    {
        public void Open()
        {
            Console.WriteLine("Opening Excel Document");
        }
    }

    // Abstract factory
    public abstract class DocumentFactory
    {
        public abstract IDocument CreateDocument();
    }

    // WordDocumentFactory class
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }

    // PdfDocumentFactory class
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }

    // ExcelDocumentFactory class
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }

    // Main method to test
    public static void Main()
    {
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        IDocument pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        IDocument excel = excelFactory.CreateDocument();
        excel.Open();
    }
}
