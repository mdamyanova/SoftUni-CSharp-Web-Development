import sys
import csv


def main():
    try:
        box_w = float(input())
        box_h = float(input())
        box_d = float(input())
        packages_filename = input()

        box_dimensions = sorted((box_w, box_h, box_d))
        packages = _load_packages(packages_filename)

        for name, dimensions in packages:
            can_fit = True
            for dim_index in range(3):
                if dimensions[dim_index] > box_dimensions[dim_index]:
                    can_fit = False
                    break
            if can_fit:
                print(name)

        return 0

    except ValueError:
        print("INVALID INPUT")


def _load_packages(input_filename):

    result = []
    with open(input_filename, encoding='utf-8') as f:
        reader = csv.reader(f)
        for row in reader:
            name = row[0]
            dimensions = [float(row[1]), float(row[2]), float(row[3])]
            result.append(
                (
                    name,
                    sorted(dimensions)
                )
            )
    return result

if __name__ == "__main__":
    sys.exit(main())
