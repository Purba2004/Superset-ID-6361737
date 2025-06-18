public class ex2 {

    // Document interface
    interface Document {
        void open();
    }

    // WordDocument class
    static class WordDocument implements Document {
        public void open() {
            System.out.println("Opening Word Document");
        }
    }

    // PdfDocument class
    static class PdfDocument implements Document {
        public void open() {
            System.out.println("Opening PDF Document");
        }
    }

    // ExcelDocument class
    static class ExcelDocument implements Document {
        public void open() {
            System.out.println("Opening Excel Document");
        }
    }

    // Abstract factory
    static abstract class DocumentFactory {
        public abstract Document createDocument();
    }

    // WordDocumentFactory class
    static class WordDocumentFactory extends DocumentFactory {
        public Document createDocument() {
            return new WordDocument();
        }
    }

    // PdfDocumentFactory class
    static class PdfDocumentFactory extends DocumentFactory {
        public Document createDocument() {
            return new PdfDocument();
        }
    }

    // ExcelDocumentFactory class
    static class ExcelDocumentFactory extends DocumentFactory {
        public Document createDocument() {
            return new ExcelDocument();
        }
    }

    // Main method to test
    public static void main(String[] args) {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document word = wordFactory.createDocument();
        word.open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdf = pdfFactory.createDocument();
        pdf.open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excel = excelFactory.createDocument();
        excel.open();
    }
}
