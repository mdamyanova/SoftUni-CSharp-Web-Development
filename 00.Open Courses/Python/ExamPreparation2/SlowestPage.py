# TODO: Finish solution

import sys
import csv

TEMP_DIFFERENCE = 4.0


def main():
    try:
        file_path = input()
        temperature_data = _load_log_lines(file_path)

        last_temperature = None
        for datetime_str, temp in temperature_data:
            if last_temperature:
                if temp - last_temperature > TEMP_DIFFERENCE:
                    print(datetime_str)
            last_temperature = temp

        return 0

    except ValueError:
        print("INVALID INPUT")


def _load_log_lines(file_path):
    with open(file_path) as f:
        for line in f:
            line = line.strip()
            url = _get_field(line, 'url="', '"')
            resp_time = _get_field(line, 'resp_t="', '"')
            yield line


def _get_field(line, prefix, suffix):
    prefix_len = len(prefix)
    idx_prefix = line.find(prefix)
    if idx_prefix >= 0:
        idx_suffix = line.find(suffix, idx_prefix + prefix_len)
        if idx_suffix >= 0:
            return line[idx_prefix:idx_suffix]
    return ''

if __name__ == "__main__":
    sys.exit(main())
