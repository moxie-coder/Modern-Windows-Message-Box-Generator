# Modern Windows Message Box Generator

Generates a customizable "Task Dialog" box - a more modern version of the old Windows message box.

## Key Features

- **Set Any Text**: Choose the text to display for each element, or leave it blank to not show that part.
- **Icons:**
    - Select from a range of default icons.
    - Use custom icons from image files. Including image files, icon files, or the icon associated with any Exe file.
    - Choose icons directly from the `imageres.dll` file using their ID.
- **Icon Selection Helper:** Click the "View Icon IDs" button to see icons from `imageres.dll`. Click any of them to automatically set it as the selected icon.
- **Icon Background Colored Bars:** Choose from various colors for the icon background bar, including green, blue, gray, red, yellow, or none.

## Examples 
<p align="center">
<img width="450" alt="Example Message Box" src="https://github.com/user-attachments/assets/6f795396-9caf-4eb3-8fbf-7e77c8d9ded5">
<img width="450" alt="Example Message Box 2" src="https://github.com/user-attachments/assets/b232caa7-8253-4ffc-ae72-d6725d99c152">
</p>

## Main Window
<p align="center">
<img width="700" alt="Main Window" src="https://github.com/user-attachments/assets/e243bafd-ed3e-43c7-8fca-179009cf6335">
</p>

## How to Compile
Requires .NET 9.0, but no other external dependencies or nuget packages.

1. Open the solution file (`TaskDialogGenerator.sln`) in Visual Studio 2022.
2. Choose the build configuration (either `Release` or `Debug`).
3. Compile by going to `Build` > `Build Solution` or, if in `Debug` configuration, `Debug` > `Start Debugging`.
