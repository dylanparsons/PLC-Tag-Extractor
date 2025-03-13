## Overview

This tool helps industrial automation engineers document PLC configurations by extracting tag names, data types, and structures from Allen-Bradley ControlLogix/CompactLogix PLCs. It traverses program structures and handles User-Defined Types (UDTs) with nested members.

## ⚠️ Important Disclaimer

This project demonstrates how to use the InGear Logix Driver to connect to Allen-Bradley PLCs. **The InGear Logix Driver is a commercial product and is not included in this repository**. Users will need to purchase their own license for the InGear Logix Driver to use this application.

This repository contains only original code and does not distribute any licensed components. The code is shared for educational and demonstration purposes only.

## Prerequisites

- Microsoft .NET Framework 4.5 or higher
- Visual Studio 2017 or higher
- InGear Logix Driver (commercial product available from [Ingear.app](https://ingear.app/))
- Network access to an Allen-Bradley PLC

## Setup Instructions

1. Clone this repository
2. Open the solution file in Visual Studio
3. Add a reference to the InGear Logix Driver DLL (you'll need to obtain this separately)
   - Right-click on "References" in the Solution Explorer
   - Select "Add Reference"
   - Browse to the location of your InGear Logix DLL
   - Select and add the reference
4. Build the solution

## Usage

1. Modify the IP address in the source code to point to your PLC:
   ```csharp
   MyPLC.IPAddress = "10.10.205.43"; // Change to your PLC's IP address
   ```

2. Run the application from Visual Studio or using the compiled executable
3. The application will connect to the PLC, extract all tags, and save them to an XML file named "PLC_Tags.xml" in the same directory as the executable

## Features

- Connects to Allen-Bradley PLCs over Ethernet/IP
- Extracts all program tags, including UDTs and their members
- Organizes tags by program
- Exports the complete tag structure to XML for documentation
- Error handling for connection and tag upload issues

## Example Output

The application generates an XML file with a structure similar to this:

```xml
<PLC IPAddress="10.10.205.43">
  <Program Name="MainProgram">
    <Tag Name="Counter" DataType="DINT" />
    <Tag Name="StartPB" DataType="BOOL" />
    <Tag Name="MachineStatus" DataType="UDT_Status">
      <Member Name="Running" DataType="BOOL" />
      <Member Name="Faulted" DataType="BOOL" />
      <Member Name="ProductCount" DataType="DINT" />
    </Tag>
  </Program>
</PLC>
```

See the included `example-output.xml` file for a more comprehensive example.

## Limitations

- Currently only supports Allen-Bradley ControlLogix/CompactLogix PLCs
- Does not extract tag values, only tag structures
- Requires direct network access to the PLC

## Future Enhancements

- Add support for reading tag values in real-time
- Implement comparison functionality to identify changes between tag snapshots
- Create a GUI interface for easier configuration and visualization
- Add filtering options for specific tag types or programs
- Support additional PLC platforms beyond Allen-Bradley

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Author

Dylan Parsons - Software Engineer specializing in industrial automation and quality control systems.

---
**Note**: This project is not affiliated with or endorsed by Allen-Bradley, Rockwell Automation, or InGear.
