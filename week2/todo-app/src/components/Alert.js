import React, { useEffect } from "react";

//create Alert
const Alert = ({type, msg, removeAlert, list }) => {
    useEffect(() => {
        const timeout = setTimeout(() => {
            removeAlert();
        }, 1500);
        return () => clearTimeout(timeout);
    }, [list, removeAlert]);
    return <p className={`alert alert-${type}`}>{msg}</p>;
};

export default Alert;
