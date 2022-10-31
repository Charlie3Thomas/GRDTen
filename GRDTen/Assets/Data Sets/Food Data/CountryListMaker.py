from tokenize import Number
import pandas as bear
import glob, os

f = open("Countries.txt", "w")
os.chdir(".")

countries = []

for filename in glob.glob("*.csv"):
    print(filename)
       
    sheet = bear.read_csv(filename)
    data = sheet.loc[:,["Entity","Code"]]
    countries += list(data["Code"] + "," + data["Entity"])

countries = list(set(countries))
countries.sort(key = str)

for i in countries :
    if not (i != i):
        f.write(i + "\n")
            
f.close()