Small Tax Application (Windows Forms):

........


Structure of the Solution
The solution consists of 3 assemblies. 
1. TaxLib An assembly that contains the logic. This assembly provides an interface for classes that know how to calculate the tax, and a default implementation of that interface is provided (in the ZA folder).
2. A unit test assembly. TaxLibTests. Tests the default tax calculator.
3. A WinForms application (TaxCalculatorApp) which allows the user to enter a salary per annum and an age and displays the tax per annum.

Features of the solution.
- The WinForms application uses MVVM (http://en.wikipedia.org/wiki/Model_View_ViewModel) pattern to decouple the UI from the logic. This pattern is overkill for such a simple application. The pattern is used for demonstration purposes. The pattern is also simplified as the model in this instance is the TaxCalculator.
- The tax library uses interfaces extensively. This decouples the tax calculator from the UI (e.g. the same UI can be used with a different implementation of the tax calculator interface). The default tax calculator is decoupled from the data (salary range table and benefits table). Should this data change the ZA tax calculator logic need not change.
- Dependency injection is used when constructing the WinForms application and the TaxCalculator, see TaxCalculatorApp.Program.cs.
- Everything (including the UI logic) is unit testable. This is achieved by programming-to-an-interface. Due to time constraints only the ZA.TaxCalculator class is unit tested.
- The application uses localization (for labels and error messages).
- The UI has input validation.