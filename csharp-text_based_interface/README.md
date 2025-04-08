## Text-based Interface
# Inventory Management Console App

A simple C# console application for managing inventories using all the C# and Foundations skills learned so far.

## 📦 Overview

This project is a text-based interface for managing objects stored in an inventory system. It’s designed to be **flexible**, **extensible**, and **versatile** for various use cases. Users can create, read, update, and delete objects. All data is persisted using **JSON** files.

## 💡 Features

- Create, read, update, and delete (CRUD) objects  
- Store and retrieve inventory data from JSON files  
- Generic class and attribute names for flexible application logic  
- Customizable user prompts and object display  
- Emphasis on clean code, user feedback, and error handling

## 🤔 Design Considerations

This app is built without strict specifications for input/output, encouraging real-world problem solving:

- You decide how input is handled (inline or step-by-step prompts)
- Object display is up to you — choose what makes sense and is readable
- Deletion can include a confirmation prompt for safety
- Helpful and descriptive error messages are expected
- Open design allows for easy extension and future improvements

## 🗂 Project Structure

InventoryManagement/  
├── InventoryLibrary/ # Core logic and object definitions  
├── InventoryManager/ # Console interface and user interaction  
├── InventoryManagement.Tests/ # NUnit test project


## 🔧 Technologies

- C#
- JSON for data storage
- NUnit for unit testing

## 📌 Notes

- Built as part of a C# learning curriculum
- Some package versions may have known security issues (consider upgrading)
- Manual code review expected — no fixed output required

## 🧪 Getting Started

**Build the solution:**
```bash
dotnet build
```
**Run the application:**

```bash
dotnet run --project InventoryManager
```
**Run the tests:**
```bash
dotnet test
```