from csv import reader


def main():
    # open connection to grade.csv file for reading
    infile = open("grades.csv", "r")
    # construct a CSVReader object to do the hard work
    csvReader = reader(infile)

    # this will be our 2D list!
    gradeData = []

    # building my 2D list
    for row in csvReader:
        # print(row)
        gradeData.append(row)
    # print report header
    print("{0:12} {1:15} {2:18} {3:5} {4:5} {5:5} {6:15} {7}".format("ID", "LAST", "FIRST", "P1", "P2", "P3",
                                                                     "CHALLENGES", "FINAL MARK"))
    # print grade data
    for grade in gradeData:
        print("{0:12} {1:15} {2:18} {3:5} {4:5} {5:5} {6:15} {7}%".format(grade[0], grade[1], grade[2], grade[3],
                                                                         grade[4], grade[5], grade[6], grade[7]))

    infile.close()

main()
