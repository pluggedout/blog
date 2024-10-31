### Linux notes
whenever setting up a new Umbraco project with SQLite on Linux, you'll want to:

Ensure the directory exists
Pre-initialize the database file using sqlite3
Then start the Umbraco application

```bash
dotnet new install Umbraco.Templates
dotnet new umbraco --name UmbracoBlog
cd UmbracoBlog

dotnet add package Microsoft.Data.Sqlite
# dotnet tool list --global
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
# dotnet add package System.ComponentModel.Annotations # for Table["Tablename"] annotations


sudo apt install sqlite3
# to create a database sqlite3 test.db
# to create tables see here: https://www.digitalocean.com/community/tutorials/how-to-install-and-use-sqlite-on-ubuntu-20-04
# snap install sqlitebrowser
sqlite3 /home/wotan/Repos/UmbracoBlog/Umbraco.sqlite.db ".databases"
```
