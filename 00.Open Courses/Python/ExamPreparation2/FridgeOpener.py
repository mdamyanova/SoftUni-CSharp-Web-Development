import sys
import csv

TEMP_DIFFERENCE = 4.0


def main():
    try:
        file_path = input()
        temperature_data = _load_temperatures(file_path)

        last_temperature = None
        for datetime_str, temp in temperature_data:
            if last_temperature:
                if temp - last_temperature > TEMP_DIFFERENCE:
                    print(datetime_str)
            last_temperature = temp

        return 0

    except ValueError:
        print("INVALID INPUT")


def _load_temperatures(file_path):
    with open(file_path) as f:
        reader = csv.reader(f)
        for row in reader:
            if len(row) != 2:
                raise ValueError("Invalid data")
            yield (row[0], float(row[1]))

if __name__ == "__main__":
    sys.exit(main())
