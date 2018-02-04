<?php
    // check if nothing inputed
    if ($_POST['fName'] == "" || $_POST['lName'] == "" || $_POST['YoB'] == "" || $_POST['SY'] == "" || $_POST['bTime'] == "" || $_POST['hTime'] == "" || $_POST['rTime'] == "" || $_POST['cTime'] == "" || $_POST['fTime'] == "" || $_POST['oTime'] == "") {
        header("Location: Challenge4.html");
        exit;
    }

    $fName = $_POST['fName'];
    $lName = $_POST['lName'];
    $yOB = $_POST['YoB'];
    $SY = $_POST['SY'];
    $bTime = $_POST['bTime'];
    $hTime = $_POST['hTime'];
    $rTime = $_POST['rTime'];
    $cTime = $_POST['cTime'];
    $fTime = $_POST['fTime'];
    $oTime = $_POST['oTime'];

// maths
    $timeLeft = 12 - $SY;
    $homework = ($hTime + $rTime + $cTime) * (195 * $timeLeft);
    $watching = ($rTime + $cTime) * (195 * $timeLeft) / 100;

// write file
    $filename = "newfile.csv";
    $writethis = "$fName, $lName, $yOB, $SY, $bTime, $hTime, $rTime, $cTime, $fTime, $oTime, $timeLeft, $homework, $watching";
        
    $myfile = @fopen($filename, "w+") or die("Couldn't open file.");
	@fwrite($myfile, $writethis) or die("Couldn't write to file.");
	$msg = "<p>File has data in it now...</p>";
	fclose($myfile);

    echo '
    <!DOCTYPE html>
    <html xml:lang="en" lang="en">
        <head>
            <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
            <title>First PHP</title>
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
        </head>
        <body>
            <h1 class="text-center">GREAT! Thanks ' . $fName . ' for responding to our survey</h1>
            <div class="well" style="padding-left: 300px;">
                <p>Full Name: ' . $fName . " $lName" . '</p>
                <p>Birth Year: ' . $yOB . '</p>
                <p>Current School Year: Grade ' . $SY . '</p>
                <a class="btn btn-primary" href="table.php" >View all info</a>
            </div>
        </body>
    </html>';