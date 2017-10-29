import sys
from decimal import Decimal

def main():
    try:
        input_exchange_rates_filename = input()
        input_amounts_filename = input()
        exchange_rates = _load_exchange_rates(input_exchange_rates_filename)
        amounts = _load_amounts(input_amounts_filename)

        for currency, amount in amounts:
            exchange_rate = exchange_rates.get(currency, None)
            if exchange_rate is not None:
                print("{:.2f}".format(amount / exchange_rate))
            else:
                print("INVALID INPUT")

    except FileNotFoundError:
        print("INVALID INPUT")


def _load_exchange_rates(input_filename):
    result = {}
    with open(input_filename, encoding='utf-8') as f:
        for line in f:
            line_elements = line.split(' ')
            currency = line_elements[0]
            exchange_rate = Decimal(line_elements[1])
            result[currency] = exchange_rate
        return result


def _load_amounts(input_filename):
    result = []
    with open(input_filename, encoding='utf-8') as f:
        for line in f:
            line_elements = line.split(' ')
            currency = line_elements[1].strip()
            amount = Decimal(line_elements[0])
            result.append((currency, amount))
    return result

if __name__ == "__main__":
    sys.exit(main())
