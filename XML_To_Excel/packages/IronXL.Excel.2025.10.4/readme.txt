IronXL: The C# Excel Library
=====================================================================================
IronXL is a C# library for creating, reading, and editing Excel spreadsheets in .NET.
=====================================================================================

Build Status: Passing
NuGet Version: 2025.10.4 [https://www.nuget.org/packages/IronXL.Excel]
License: Commercial

✨ KEY FEATURES

  * ➕ Create Excels: Generate new Excel (XLSX, XLS) and CSV files programmatically

  * ✍️ Edit Excels: Read, write, and update data at any level, from individual cells to entire worksheets.

  * 🔒 Protect Excels: Encrypt workbooks, set open passwords, and manage user permissions at the sheet or cell level.

  * 🎨 Customize Excels: Customize cell appearance, fonts, colors, and borders, and precisely control row/column dimensions and visibility.

  * 📊 Process & Display Data: Execute complex formulas, sort and filter data to create insightful charts and graphs.


📦 INSTALLATION

To install IronXL via the NuGet Package Manager Console, run the following command:

    PM> Install-Package IronXL.Excel


🚀 QUICK START

Creating and writing to an Excel file is simple. After installing the package, you can create a spreadsheet with just a few lines of code:

    using IronXL;

    // Create a new Excel Workbook
    WorkBook workBook = WorkBook.Create();

    // Get the first worksheet
    WorkSheet workSheet = workBook.DefaultWorkSheet;

    // Add text to cell A1
    workSheet["A1"].Value = "Hello World from IronXL!";

    // Save the Excel file
    workBook.SaveAs("MyFirstExcel.xlsx");

For more detailed examples, please visit our website's quick-start guide: https://ironsoftware.com/csharp/excel/docs/


📚 DOCUMENTATION

Our documentation is structured to help you learn effectively, whether you're a beginner or an expert.

  * 🎓 Tutorials: Step-by-step guides to help you build your first Excel application.
    * C# Excel Tutorials: https://ironsoftware.com/csharp/excel/tutorials/how-to-read-excel-file-csharp/

  * 🛠️ How-To Guides: Practical, goal-oriented instructions to solve specific problems.
    * Code Examples: https://ironsoftware.com/csharp/excel/examples/read-excel/
    * How-To Articles: https://ironsoftware.com/csharp/excel/how-to/create-spreadsheet/

  * 📖 Reference: Detailed technical descriptions of the API and its components.
    * API Reference: https://ironsoftware.com/csharp/excel/object-reference/api/

  * 🤔 Demos: Demonstrations that showcase how IronXL works the way it does.
    * Book a Live Demos: https://ironsoftware.com/csharp/excel/docs/#booking-demo


❓ FAQs

  * IronXL Data Size Limitation:    https://ironsoftware.com/csharp/excel/troubleshooting/file-size-limits/
  * Data Validation Limitation:     https://ironsoftware.com/csharp/excel/troubleshooting/excel-limitation-data-validation-for-string-lists/
  * IronXL Security CVE:            https://ironsoftware.com/csharp/excel/troubleshooting/ironxl-security-cve/

🤝 GETTING HELP & SUPPORT

Have a question or running into an issue?

  * Email Support: Reach out to our team directly at support@ironsoftware.com.
  * Report a Bug: https://ironsoftware.com/ticket-submission/
  * Community: https://ironsoftware.com/company/iron-slack-community/


💻 COMPATIBILITY

  * Languages: C#, F#, VB.NET
  * Platforms: .NET 9, .NET 8, .NET 7, .NET 6, .NET 5, Core 2x & 3x, Standard 2
  * Framework: .NET Framework 4.6.2 (and above)
  * App Models: Console, Web, Desktop Apps
  * Operating Systems: Windows, macOS, Linux (Debian, CentOS, Ubuntu)
  * Cloud & Containerization Platforms: Azure, AWS, Docker
  * IDEs: Microsoft Visual Studio, JetBrains ReSharper, JetBrains Rider


📝 LICENSE

IronXL is a commercially licensed product.
  * Trial License: https://ironsoftware.com/csharp/excel/licensing/new/#trial-license
  * Purchase a License: https://ironsoftware.com/csharp/excel/licensing/new/
