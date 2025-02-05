window.preventDefaultEnter = function () {
    document.addEventListener("keydown", function (event) {
        if (event.key === "Enter") {
            let activeElement = document.activeElement;
            if (activeElement.tagName === "INPUT" || activeElement.tagName === "TEXTAREA") {
                event.preventDefault();
            }
        }
    });
};
