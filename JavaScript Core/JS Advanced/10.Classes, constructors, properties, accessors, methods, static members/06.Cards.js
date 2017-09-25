(function solve () {
    let Faces = [ '2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let Suits = {
        SPADES: '♠',
        HEARTS: '♥',
        DIAMONDS: '♦',
        CLUBS: '♣'
    };

    class Card {
        constructor (face, suit) {
            this.face = face;
            this.suit = suit;
        }

        set face (newFace) {
            if (Faces.indexOf(newFace) === -1) {
                throw new Error('Invalid face: ' + newFace);
            }

            this._face = newFace;
        }

        get face () {
            return this._face;
        }

        set suit (newSuit) {
            let allowedSuitValues = Object.keys(Suits).map(key => Suits[key]);
            console.log(allowedSuitValues);
            if (allowedSuitValues.indexOf(newSuit) === -1) {
                throw new Error('Invalid suit: ' + newSuit);
            }

            this._suit = newSuit;
        }

        get suit () {
            return this._suit;
        }
    }

    return {
        Suits: Suits,
        Card: Card
    };

})();