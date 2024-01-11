AddNote
=========

Simple nuget library and command-line tool for adding external notes on Neuro-Feature tokens

Projects
----------

This repository contains the following projects:

| Project                                | Description                                                                  |
|:---------------------------------------|:-----------------------------------------------------------------------------|
| [AddNote](AddNote)                     | Command-line tool you can use to automate adding external notes from script. |
| [NeuroFeatureNotes](NeuroFeatureNotes) | Class library (and nuget) for adding external notes to Neuro-Feature tokens. |

Command-line arguments for **AddNote** command
--------------------------------------------------

The following table lists available command-line arguments for the [AddNote](AddNote) command-line tool. Arguments that are
not provided will trigger the tool to prompt the user for the information.

| Argument               | Description                                                                         |
|:-----------------------|:------------------------------------------------------------------------------------|
|`-d DOMAIN`             | Specifies the domain name of the Neuron hosting the token.                          |
|`-domain DOMAIN`        | Same as -d DOMAIN.                                                                  |
|`-c FILENAME`           | Specifies the file name of the certificate to use to authenticate call, using mTLS. |
|`-crt FILENAME`         | Same as -c FILENAME.                                                                |
|`-cert FILENAME`        | Same as -c FILENAME.                                                                |
|`-certificate FILENAME` | Same as -c FILENAME.                                                                |
|`-p PASSWORD`           | Specifies the password to use when authenticating the user name.                    |
|`-pwd PASSWORD`         | Same as -p PASSWORD.                                                                |
|`-password PASSWORD`    | Same as -p PASSWORD.                                                                |
|`-t TOKEN_ID`           | Specifies the ID of the token to add a note to.                                     |
|`-tid TOKEN_ID`         | Same as -t TOKEN_ID.                                                                |
|`-token TOKEN_ID`       | Same as -t TOKEN_ID.                                                                |
|`-tokenid TOKEN_ID`     | Same as -t TOKEN_ID.                                                                |
|`-n NOTE`               | Specifies the contents of the note, in-line. Can be text or XML.                    |
|`-note NOTE`            | Same as -n NOTE.                                                                    |
|`-f FILENAME`           | Specifies the file-name of the contents of the note. Can be a text or XML file.     |
|`-fn FILENAME`          | Same as -f FILENAME.                                                                |
|`-file FILENAME`        | Same as -f FILENAME.                                                                |
|`-filename FILENAME`    | Same as -f FILENAME.                                                                |
|`-?`                    | Prints this help.                                                                   |
|`-h`                    | Same as -?.                                                                         |
|`-help`                 | Same as -?.                                                                         |


