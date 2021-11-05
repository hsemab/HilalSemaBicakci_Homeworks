import React, { useState, createContext } from "react";

export const CalcContext = createContext();

export const CalcProvider = ({ children }) => {
  const [mainText, setMainText] = useState("0");
  const [resetMainTextNextTime, setResetMainTextNextTime] = useState(true);

  const [lastResult, setLastResult] = useState();
  const [currentOperation, setCurrentOperation] = useState();

  const handleKeyClick = (isNumber, label, operator) => {
    if (isNumber) {
      if (resetMainTextNextTime) {
        setMainText(label);
        setResetMainTextNextTime(false);
      } else {
        setMainText((mainText) => {
          return mainText + label;
        });
      }
    }

    if (operator) {
      setCurrentOperation(label);
      setResetMainTextNextTime(true);
      switch (label) {
        case "+":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(Number(mainText) + lastResult);
            setMainText(Number(mainText) + lastResult);
          }
          break;
        case "-":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult - Number(mainText));
            setMainText(Number(mainText) - lastResult);
          }
          break;
        case "x":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult * Number(mainText));
          }
          break;
        case "/":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult(lastResult / Number(mainText));
          }
          break;
        case "=":
          if (!lastResult) {
            setLastResult(Number(mainText));
          } else {
            setLastResult("");
            setMainText(Number(mainText))
          }
          break;
        default:
          break;
      }
    }
  };

  return (
    <CalcContext.Provider
      value={{
        mainText,
        setMainText,
        handleKeyClick,
        resetMainTextNextTime,
        setResetMainTextNextTime,
        lastResult,
        currentOperation,
      }}
    >
      {children}
    </CalcContext.Provider>
  );
};