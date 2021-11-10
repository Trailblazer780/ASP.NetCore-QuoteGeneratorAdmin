function getFileData(myFile){
    let file = myFile.files[0];  
    let filename = file.name;
    document.getElementById("fileNameToUpload").innerHTML = filename;
}

function deleteFile(fileName){
    console.log(fileName);
}