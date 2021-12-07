// get the file data and display it in the feedback
function getFileData(myFile){
    let file = myFile.files[0];  
    let filename = file.name;
    document.getElementById("fileNameToUpload").innerHTML = filename;
}
// testing puposes
function deleteFile(fileName){
    console.log(fileName);
}
// timeout to get rid of the quote sucesffully added
window.setTimeout((function(){
    if(document.getElementById("feedbackData").innerHTML == "Quote Succesfully added"){
        document.getElementById("feedbackData").innerHTML = "";
    }
}), 8000);

window.setTimeout((function(){
    if(document.getElementById("deletedData").innerHTML == "Quote Succesfully deleted"){
        document.getElementById("deletedData").innerHTML = "";
    }
}), 8000);