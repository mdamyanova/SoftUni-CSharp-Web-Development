import requests
from decimal import Decimal

API_URL_EXCHANGE_RATE_LATEST = 'http://api.fixer.io/latest?base=BGN'
API_TIMEOUT = 20
TARGET_CURRENCY = 'BGN'


def main():

    # get the input

    original_currency = input("Enter currency: ")
    original_amount_str = input("Enter sum: ")
    original_amount = Decimal(original_amount_str)

    # get converted values

    response = requests.get(API_URL_EXCHANGE_RATE_LATEST,
                            timeout=API_TIMEOUT)
    exchange_values_info = response.json()
    exchange_rates = exchange_values_info.get('rates', {})

    exchange_rate_to_target_currency = exchange_rates.get(original_currency, None)

    if not exchange_rate_to_target_currency:
        print("There's no info for currency {} ".format(original_currency))
        return 1
    else:
        exchange_rate_to_target_currency = Decimal(exchange_rate_to_target_currency)

    result = original_amount / exchange_rate_to_target_currency
    print()
    print("Converted value in {} : {:.2f}".format(TARGET_CURRENCY, result))

if __name__ == '__main__':
    main()