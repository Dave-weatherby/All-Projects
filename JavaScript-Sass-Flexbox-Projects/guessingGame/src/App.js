let targetNum;
let guessCount;
let won = 0;
let lose = 0;
let regVal = new RegExp(/^(1-9)||(1-9)(0-9)||100$/);
let guessArchive;
const MAX_GUESS = 10;


function onGuess(b) {

    let lblfeed = document.getElementById("lblFeedback");
    let guess = document.getElementById("txtGuess").value;

    if (regVal.test(guess)) {

        if (guessRep(guess)) {
            guess = Number(guess);

            guessCount++;
            document.getElementById("lblGuessCount").innerHTML = guessCount +1;
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
        }else {
            lblfeed.innerHTML = "You already guessed " + guess;
        }
        
    }else {
        lblfeed.innerHTML = guess + " is invalid please use a number between 1 and 100";
    }
    document.getElementById("txtGuess").value = "";
    document.getElementById("txtGuess").focus();
}

function guessRep(usGuess) {
    for (let guess of guessArchive) {
        if (guess == usGuess) return false;
    }
    return true;
}

function reset() {

    guessArchive = [];
    guessCount = 0;
    targetNum = Math.floor(Math.random() *100) +1;

    document.getElementById("lblGuessCount").innerHTML = guessCount +1;
    document.getElementById("lblWon").innerHTML = won;
    document.getElementById("lblLost").innerHTML = lose;
    console.log("target", targetNum);
}

function main() {

    document.getElementById("btnSubmit").addEventListener("click", onGuess);

    reset();
}

main();