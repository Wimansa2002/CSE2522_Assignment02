# CSE2522 – Assignment 02  
## Software Testing and Validation – Selenium Automation  

**Student Name:** M. W. S. Ekanayaka  
**Student ID:** FC222011  
**Course Code:** CSE2522 – Software Testing and Validation  
**Assignment:** Assignment 02  
**University:** University of Sri Jayewardenepura  

---

## 📌 Assignment Overview  

This assignment focuses on automating **UI test cases** using **Selenium WebDriver** with **C#** and the **NUnit Framework**.  
The test automation is implemented following the **Page Object Model (POM)** design pattern to ensure clean, reusable, and maintainable test code.

All required test scenarios from the **UI Testing Playground** have been successfully automated and validated.

---

## 🛠️ Technologies Used  

- **C# (.NET 10.0)**  
- **Selenium WebDriver**  
- **NUnit Framework**  
- **Firefox Browser**  
- **GeckoDriver**  
- **Visual Studio / VS Code**

---

## 📁 Project Structure  

```

CSE2522_Assignment02/
│
├── Base/             
├── Pages/             
├── Tests/           
├── .editorconfig
├── .gitattributes     
├── ,gitignore
├── CSE2522_Assignment02.slnx
└── README.md

````

This structure separates:
- UI interaction logic (Pages)
- Test execution logic (Tests)
- Browser driver handling
- Reusable helper utilities

---

## 🧪 Test Automation Details  

- Implemented using the **Page Object Model (POM)**  
- Selenium WebDriver used for browser interactions  
- NUnit framework used for assertions and test execution  
- Automated tests executed on **Firefox browser** using **GeckoDriver**

---

## ▶️ How to Run the Tests  

1. **Clone the repository**
  
   git clone https://github.com/Wimansa2002/CSE2522_Assignment02.git

2. **Open the solution**

   * Open `CSE2522_Assignment02.sln` using **Visual Studio**

3. **Restore NuGet packages**

   * Automatically restored when opening the solution

4. **Install required tools**

   * Install **Firefox Browser**
   * Ensure **GeckoDriver** is available in system PATH

5. **Run tests**

   * Open **Test Explorer** in Visual Studio
   * Run all tests to execute the automation suite

---

## 📊 Expected Output

* All automated test cases should pass successfully
* Test results will be visible in **Test Explorer**
* Automated validation of UI Testing Playground scenarios

---

## 📌 Notes

* Ensure Firefox and GeckoDriver versions are compatible
* Follow POM best practices when extending test cases
* Project is compatible with **.NET 10.0**

---

## ✅ Conclusion

This project demonstrates effective **UI automation testing** using Selenium WebDriver with C#, structured using the **Page Object Model** and tested through the **NUnit framework**.
The solution provides a clean, scalable approach to automated UI testing aligned with industry best practices.

---


