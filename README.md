Built in C#, was part of some internal libraries we have used over time to handle localization. Command-line utility that is easy to roll into a build process with NANT for example or MSBuild. We do plan on adding features to it in the future.

* **Requires** .NET framework 4.0 to be installed.

# Overview #

### 0.0.3+

Options for usage .

1. Use the compiled binaries located in the project **bin/** folder.
2. Run the **build.bat** script to compile and generate the binaries. The script will copy files into a *build/* directory in ZIP format. 
3. Fork the project, compile it, and build your own release using some free C# tools or Visual Studio 2010+.

### <0.0.2

There is an option to download older compiled versions 0.0.2 and 0.0.1.

1. Download the executable (.exe) from [Downloads][1]. Extract the archive and run the utility from the command-line.

## XLIFF Format ##

The format for the source XLIFF file is [XLIFF 1.1][3]. Please take extra care in using the *target-language* property making sure it is set and also the *id* attribute of the _trans-unit_ node. The *id* is very important as it is used to set the actual key as part of the key/value pair in your code. The *id* is what your Java or .Net application will use as the key to look-up in the _properties_ file or _resource_ file.

Below is an example of an XLIFF 1.1 file in French:

    <?xml version="1.0" encoding="UTF-8" ?>
        <xliff version="1.1" xmlns="urn:oasis:names:tc:xliff:document:1.1" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="urn:oasis:names:tc:xliff:document:1.1 xliff-core-schema-1.1.xsd">
            <file datatype="plaintext" original="" source-language="en-US" target-language="fr">
                <body>
           <trans-unit approved="no" id="form.label.username" extradata="" xml:space="preserve">
              <source xml:lang="en-US">Username</source>
              <target xml:lang="fr">Nom d'utilisateur</target>
           </trans-unit>
           <trans-unit approved="no" id="form.label.password" extradata="" xml:space="preserve">
              <source xml:lang="en-US">Password</source>
              <target xml:lang="fr">Mot de passe</target>
           </trans-unit>
            </body>
        </file>
    </xliff>

## Usage ##

You can run straight from the command-line or build the project from source.

### Command-line (.exe) ###

Run the XLIFF parser at the command-line.

* Open the command line; Start Menu > type 'cmd' into the input > Enter key.
* The output will be in same directory as the XLF file you passed as the first arguement. In this case where the xlf target language is French Canadian; fr-CA, creating the generated output on the Desktop **C:\Users\USERNAME\Desktop\ApplicationResources_fr-CA.properties**.
* Arguments are '--help', and '--xliff=' as the fully qualified input filename like **C:\Users\USERNAME\Desktop\example.xlf**.

Command-line input example:

    $ XliffParser.exe --xliff=C:\Users\USERNAME\Desktop\example.xlf

Will generate the files and following output:
    
    ApplicationResources_fr-CA.properties
    ApplicationResources_fr-CA.resources
    ApplicationResources_fr-CA.strings

    [INFO]  Generated fr-CA resource file
    [INFO]  Generated fr-CA properties file
    [INFO]  Generated fr-CA strings file

The **.strings** file is only generated in 0.0.3+

### Build from source ###

Compile the project yourself.

* Clone the project from GitHub.
* Use Visual Studio 2010 or SharpDevelop ([SharpDevelop][2]).
* Requires the .NET framework installed, recommend 4.0.
* Open the project SLN file with Visual Studio 2010 or SharpDevelop.
* Build the project; Debug or Release.
* The executable will be in \XliffParser\bin\Debug or Release\ folder.

## Roadmap ##

* Create a pre-compiled version and bin directory.
* Add more unit tests.
* Add options for iOS/Cocoa and NSLocalization files (.string file).
* Port to a Grunt JS task.

### Creators

[Matthew Teece](http://github.com/mteece)
[@doctorteece](https://twitter.com/doctorteece)


## License

I18N is available under the MIT license. See the LICENSE file for more info.

[1]: https://github.com/PixelMEDIA/I18N/downloads "I18N"
[2]: http://www.icsharpcode.net/OpenSource/SD/Download/#SharpDevelop4x "SharpDevelop4x"
[3]: http://docs.oasis-open.org/xliff/xliff-core/xliff-core.html "XLIFF 1.2"