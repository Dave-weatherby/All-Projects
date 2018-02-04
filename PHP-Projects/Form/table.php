<?php
    // ----------open the file
	$filename = "newfile.csv";
	$whattoread = @fopen($filename, "r") or die("Couldn't open file");
	$file_contents = fread($whattoread, filesize($filename));
	$new_file_contents = nl2br($file_contents);
	$msg = "Boom I got yo contents:<br>$new_file_contents";
	fclose($whattoread);
    
    // --------------Explode the file into an array
    $file = explode(', ', $new_file_contents);

    $fName = $file[0];
    $lName = $file[1];
    $yOB = $file[2];
    $SY = $file[3];
    $bTime = $file[4];
    $hTime = $file[5];
    $rTime = $file[6];
    $cTime = $file[7];
    $fTime = $file[8];
    $oTime = $file[9];
    $timeLeft = $file[10];
    $homework = $file[11];
    $watching = $file[12] . "%";

    echo '
    <!DOCTYPE html>
    <html xml:lang="en" lang="en">
        <head>
            <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
            <title>First PHP</title>
            <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
        </head>
        <body>
            <div class="well">
                <p class="form-control">First Name: ' . $fName . '</p>
                <p class="form-control">Last Name: ' . $lName . '</p>
                <p class="form-control">Year of Birth: ' . $yOB . '</p>
                <p class="form-control">Current Year at School: ' . $SY . '</p>
                <p class="form-control">The Tie You go to Bed: ' . $bTime . '</p>
                <p class="form-control">The Time You Spend on Homework: ' . $hTime . '</p>
                <p class="form-control">The Time You Spend on TV/Youtube/Netflex: ' . $rTime . '</p>
                <p class="form-control">The Time You Spend Using the Computer/Playing Video Games: ' . $cTime . '</p>
                <p class="form-control">The Time You Spend With Friends and Family: ' . $fTime . '</p>
                <p class="form-control">The Time You Spend Outside: ' . $oTime . '</p>
                <p class="form-control">Years Remaining Till Graduation: ' . $timeLeft . '</p>
                <p class="form-control">How Long You Will do Homework plus How Much Screen Time: ' . $homework . '</p>
                <p class="form-control">Percentage of Time Awake in front of a Screen: ' . $watching . '</p>
            </div>
            <a class="btn btn-primary" href="Challenge4.html" >Back to Form</a>
        </body>
    </html>';