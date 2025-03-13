# PLC Tag Extractor

## Overview
This repository contains sample code demonstrating how to extract tag structures from Allen-Bradley ControlLogix/CompactLogix PLCs using the InGear Logix Driver. The code traverses program structures and handles User-Defined Types (UDTs) with nested members, exporting them to XML.

## ⚠️ Important Disclaimer
This code requires the InGear Logix Driver, which is a commercial product not included in this repository. Users will need to purchase their own license to use this code.

## Code Sample
This repository contains a single Program.cs file that demonstrates:
- Connecting to an Allen-Bradley PLC using the InGear Logix Driver
- Extracting tag names and data types from all programs
- Processing User-Defined Types (UDTs) and their members
- Exporting the tag structure to an XML file

## Using This Code
To use this code in your own project:

1. Create a new C# Console Application in Visual Studio
2. Add a reference to the InGear Logix Driver (commercial product)
3. Replace your Program.cs with the one provided here
4. Modify the IP address to point to your PLC
5. Build and run the application

## Example Output
The application generates an XML file with a structure similar to this:
```xml
<PLC IPAddress="10.10.205.43">
  <Program Name="MainProgram">
    <Tag Name="Counter" DataType="DINT" />
    <Tag Name="MachineStatus" DataType="UDT_Status">
      <Member Name="Running" DataType="BOOL" />
      <Member Name="ProductCount" DataType="DINT" />
    </Tag>
  </Program>
</PLC>
