(function e(t,n,r){function s(o,u){if(!n[o]){if(!t[o]){var a=typeof require=="function"&&require;if(!u&&a)return a(o,!0);if(i)return i(o,!0);var f=new Error("Cannot find module '"+o+"'");throw f.code="MODULE_NOT_FOUND",f}var l=n[o]={exports:{}};t[o][0].call(l.exports,function(e){var n=t[o][1][e];return s(n?n:e)},l,l.exports,e,t,n,r)}return n[o].exports}var i=typeof require=="function"&&require;for(var o=0;o<r.length;o++)s(r[o]);return s})({1:[function(require,module,exports){
"use strict";

//let course = "blah";

var TARGET_DIV = "insultSpot";
var VICTIM_NAME = "Sean";

function randomMe() {
    var low = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : 1;
    var high = arguments.length > 1 && arguments[1] !== undefined ? arguments[1] : 100;

    var randomNum = Math.floor(Math.random() * (high - low + 1)) + low;
    return randomNum;
}

function insultMe(victim) {

    // random noun generation
    // get random number for noun
    var randomNum = randomMe(1, 5);

    // == != >= <= < >
    // === !==
    var noun = "";
    if (randomNum == 5) {
        noun = "jerk";
    } else if (randomNum == 4) {
        noun = "dork";
    } else if (randomNum == 3) {
        noun = "simpleton";
    } else if (randomNum == 2) {
        noun = "geek";
    } else {
        noun = "doofus";
    }

    //console.log("noun: " + noun);

    // random adjective generation
    randomNum = randomMe(1, 5);
    var adjective = "";
    if (randomNum == 5) {
        adjective = "goofy";
    } else if (randomNum == 4) {
        adjective = "dorky";
    } else if (randomNum == 3) {
        adjective = "bumbling";
    } else if (randomNum == 2) {
        adjective = "awkward";
    } else {
        adjective = "bewildering";
    }

    // APPROACH I
    //let insult = "\"" + victim + " is a " + adjective + " " + noun + "!\"";
    // APPROACH II
    var insult = "\"" + victim + " is a " + adjective + " " + noun + "!\"";

    return insult;
}

// --------------------------------------------------- main method
function main() {
    /*
    let course = "Client Side Programming";
    course = "BLAH!";
    let grade = 87.5;
    grade = "A";
    let challengeCount = 10;
    */

    /*
    let course = "Client Side Programming";
    console.log(course);
    */

    //console.log("random test: " + randomMe(5,10));
    //console.log("random test: " + randomMe());

    var target = document.getElementById(TARGET_DIV);
    target.innerHTML = insultMe(VICTIM_NAME);
}

main();

},{}]},{},[1])

//# sourceMappingURL=build.js.map
