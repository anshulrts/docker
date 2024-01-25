from urllib.request import urlretrieve
import time

print("Start")

url = ("https://api.worldbank.org/v2/en/indicator/NY.GDP.MKTP.CD?downloadformat=csv")

filename = "gdp_by_country.zip"

path, headers = urlretrieve(url, filename)

print("file downloaded")

time.sleep(300)

print("closing now")