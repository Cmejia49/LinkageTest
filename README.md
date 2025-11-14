# Exercise 1 – Amount to Words Converter (VB.NET WebForms)

This project is an implementation of **Exercise 1** from the coding test.

The application is built using:

- ASP.NET WebForms  
- VB.NET  
- .NET Framework 4.8  
- Visual Studio 2019 / 2022  

The web page accepts a numeric amount and converts it into its **English words representation**, limited to values up to **999,999.99 pesos**.

---

## What the Project Does

- Provides a simple web page (`Default.aspx`) where the user can enter a numeric amount.
- Converts the numeric value (e.g. `2523.04`) into a words format:  
  `Two thousand five hundred twenty-three and 04/100 pesos`
- Supports amounts from **0.00** up to **999,999.99**.
- Uses ASP.NET WebForms validators to ensure:
  - The amount is required.
  - The amount is in a valid numeric format (integer or with up to two decimal places).
- All conversion logic (number-to-words) is implemented inside `Default.aspx.vb` in the `_Default` page class.

---

## How to Run the Project in Visual Studio

### Requirements

- Visual Studio 2019 or 2022  
- .NET Framework 4.8  
- IIS Express (installed by default with Visual Studio)

### Steps

1. Clone or download the repository from GitHub.
2. Open the solution file (`.sln`) in Visual Studio.
3. Ensure the web project is configured to use:
   - **.NET Framework 4.8**
   - **IIS Express** as the web server
4. Set the web project as the **Startup Project** (if it is not already).
5. Run the project using:
   - `F5` (Start Debugging), or  
   - `Ctrl + F5` (Start Without Debugging)
6. The browser will open the home page (`Default.aspx`), which contains the Exercise 1 converter.

### Usage

1. Enter an amount such as `1523.75` into the input box.
2. Click the **Convert** button.
3. The converted text will appear in the result area.

#### Example

- **Input:** `2523.04`  
- **Output:** `Two thousand five hundred twenty-three and 04/100 pesos`

---

## Important Notes / Considerations for the Reviewer

- The conversion logic supports **thousands only** (from `0.00` to `999,999.99` pesos).  
  Larger values are rejected with a validation message.
- Values are rounded to two decimal places before conversion, and the decimal part is always shown as `XX/100`.
- The word output is formatted with:
  - Lowercase words
  - A capitalized first letter for the final result
  - Hyphens between tens and ones (e.g. `twenty-three`)
- The implementation focuses on:
  - Clear, readable VB.NET code
  - Simple, maintainable structure
  - Staying within the scope of Exercise 1 as defined in the test.
