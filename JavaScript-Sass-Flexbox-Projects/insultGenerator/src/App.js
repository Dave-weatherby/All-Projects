const TARGET_DIV = "insultSpot";
const VICTIM_NAME = "You";

// calculate random number
function randomMe(low = 1, high = 100){
    let randomNum = Math.floor(Math.random() * (high - low + 1)) + low;
    return randomNum;
}

//takes random number an chooses a noun and adjective
function insultMe(victim) {

    let randomNum = randomMe(1,5);

    // noun
    let noun = "";
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

    randomNum = randomMe(1,5);
    
    // adjective
    let adjective = "";
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

    let insult = `"${victim} are a ${adjective} ${noun}!"`;

    return insult;
}

function main() {
    
    let target = document.getElementById(TARGET_DIV);
    target.innerHTML = insultMe(VICTIM_NAME);
}

main();