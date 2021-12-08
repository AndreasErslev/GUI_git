//Assumes jwt is a string
export default jwt => {
    const payload = jwt.split(".")[1]; //Grab the middle data
    let information = JSON.parse(atob(payload));

    //Make some props easier to access
    Object.keys(information).forEach(key => {
        if (key.indexOf("role") !== -1) {
            information["role"] = information[key];
        }
        if (key.indexOf("emailaddress") !== -1) {
            information["emailAddress"] = information[key];
        }
    });

    return information;
};
