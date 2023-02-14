# Bitcoin Ticker
A web platform that fetches Bitcoin price (BTC/USD) from multiple sources and presents them to the user.
## Prerequisite
You need to have docker installed and running linux containers.
## Instructions
- Clone/download the repo.
- Navigate to "BitcoinTicker" folder.
- Open command window.
- Run "docker-compose build".
- Run "docker-compose up".

## Notes
Bitstamp refuses the connection from the application or from postman, it works sometimes only from the web page URL, so using it from the app will fail. Test using Bitfinex only.

## Todo:
- Complete missing implementations in EfCoreRepositoryBase.
- Add unit tests.
