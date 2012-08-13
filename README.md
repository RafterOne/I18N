Built in C#, was part of some internal libraries we have used over time to handle localization. Command-line utility that is easy to roll into a build process with NANT for example or MSBuild. We do plan on adding features to it in the future.

* **Requires** .NET framework 4.0 to be installed.

# Overview #

You really have two options depending how in depth you want to go.

1. Download the executable (.exe) from [Downloads][1]. Extract the archive and run the utility from the commandline.
2. Fork the source code, compile it, and build your own release for yourself using some free C# tools or Visual Studio 2010.

## Command-line (.exe) ##

Download the (.exe) from [Downloads][1]

* Download the latest from Download Packages in ZIP format.
* Once the contents are downloaded, navigate to the download folder; typically **C:\Users\USERNAME\Downloads**.
* You will see the contents like **I18N-0.0.1.zip**.
* Extract it here or to your desired location. For this exercise **C:\Users\USERNAME\Downloads\I18N-0.0.1**.
* Note the folder and path.
 
Run the XLIF parser at the command-line.

* Open the command line; Start Menu > type 'cmd' into the input > Enter key.
* For example a command would be like: **C:\Users\USERNAME\Downloads\I18N-0.0.1\XliffParser.exe C:\Users\USERNAME\Desktop\example.xlf** where the xlf target language is French Canadian; fr-CA.
* The output will be in same directory as the XLF file you passed as the first arguement. In this case creating the generated output on the Desktop **C:\Users\USERNAME\Desktop\ApplicationResources.properties_fr-CA**.

## Build from source ##

Compile the project yourself.

* Fork the project on GitHub.
* Use Visual Studio 2010 or SharpDevelop.
* In case you do not have Visual Studio 2010 installed download [SharpDevelop][2].
* Requires the .NET framework installed, recommend 4.0.
* Open the project SLN file with Visual Studio 2010 or SharpDevelop.
* Build the project; Debug or Release.
* The executable will be in \XliffParser\bin\Debug or Release.

[1]: https://github.com/PixelMEDIA/I18N/downloads "I18N"
[2]: http://www.icsharpcode.net/OpenSource/SD/Download/#SharpDevelop4x "SharpDevelop4x"