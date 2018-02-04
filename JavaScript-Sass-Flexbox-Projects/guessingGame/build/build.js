(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
"use strict";

var targetNum = void 0;
var guessCount = void 0;
var won = 0;
var lose = 0;
var regVal = new RegExp(/^(1-9)||(1-9)(0-9)||100$/);
var guessArchive = void 0;
var MAX_GUESS = 10;

function onGuess(b) {

    var lblfeed = document.getElementById("lblFeedback");
    var guess = document.getElementById("txtGuess").value;

    if (regVal.test(guess)) {

        if (guessRep(guess)) {
            guess = Number(guess);

            guessCount++;
            document.getElementById("lblGuessCount").innerHTML = guessCount + 1;
            guessArchive.push(guess);

            if (guess > targetNum) {
                lblfeed.innerHTML = "The number is lower than " + guess;
            } else if (guess < targetNum) {
                lblfeed.innerHTML = "The number is higher than " + guess;
            } else if (guess == targetNum) {
                lblfeed.innerHTML = "Your a winner " + guess + " is the right answer!</br>" + guessCount + " guesses made";
                won++;
                reset();
            }
            if (guessCount == MAX_GUESS && guess != targetNum) {
                lblfeed.innerHTML = "Your a loser ran out of guesses";
                lose++;
                reset();
            }
        } else {
            lblfeed.innerHTML = "You already guessed " + guess;
        }
    } else {
        lblfeed.innerHTML = guess + " is invalid please use a number between 1 and 100";
    }
    document.getElementById("txtGuess").value = "";
    document.getElementById("txtGuess").focus();
}

function guessRep(usGuess) {
    var _iteratorNormalCompletion = true;
    var _didIteratorError = false;
    var _iteratorError = undefined;

    try {
        for (var _iterator = guessArchive[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
            var guess = _step.value;

            if (guess == usGuess) return false;
        }
    } catch (err) {
        _didIteratorError = true;
        _iteratorError = err;
    } finally {
        try {
            if (!_iteratorNormalCompletion && _iterator.return) {
                _iterator.return();
            }
        } finally {
            if (_didIteratorError) {
                throw _iteratorError;
            }
        }
    }

    return true;
}

function reset() {

    guessArchive = [];
    guessCount = 0;
    targetNum = Math.floor(Math.random() * 100) + 1;

    document.getElementById("lblGuessCount").innerHTML = guessCount + 1;
    document.getElementById("lblWon").innerHTML = won;
    document.getElementById("lblLost").innerHTML = lose;
    console.log("target", targetNum);
}

function main() {

    document.getElementById("btnSubmit").addEventListener("click", onGuess);

    reset();
}

main();

},{}]},{},[1])

//# sourceMappingURL=build.js.map
