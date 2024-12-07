To import data from a CSV file into an SQLite table, you can use the SQLite command-line interface (CLI). Below are the steps to accomplish this:

### 1. Prepare Your CSV File
Make sure your CSV file is well-structured, with the first row containing the column names and each subsequent row containing the data.

Example of a CSV file (`data.csv`):
```
id,name,age
1,John Doe,28
2,Jane Doe,32
3,James Smith,45
```

### 2. Create the SQLite Database and Table
First, create an SQLite database and a table that matches the structure of your CSV data.

```sql
-- Create the SQLite database
sqlite3 my_database.db

-- Inside the SQLite shell, create a table
CREATE TABLE people (
    id INTEGER PRIMARY KEY,
    name TEXT,
    age INTEGER
);
```

### 3. Import the CSV Data into the SQLite Table
Use the `.import` command to load the CSV data into the table. 

```sh
sqlite3 my_database.db
```

Once inside the SQLite shell, set the mode to CSV and import the file:

```sql
.mode csv
.import data.csv people
```

- `.mode csv` tells SQLite to treat the input as CSV format.
- `.import data.csv people` imports the CSV file `data.csv` into the `people` table.

### 4. Verify the Data Import
You can verify that the data has been imported correctly by running a `SELECT` query:

```sql
SELECT * FROM people;
```

### 5. Exit the SQLite Shell
To exit the SQLite shell, use:

```sh
.exit
```

### Example Summary

Assuming your CSV file is named `data.csv` and looks like the example above, and you want to import it into a table named `people` in a database named `my_database.db`, you would:

1. Start SQLite: `sqlite3 my_database.db`
2. Create the table (if not already created).
3. Use the `.mode csv` and `.import` commands to import the data.

These steps should successfully load your CSV data into the SQLite database.