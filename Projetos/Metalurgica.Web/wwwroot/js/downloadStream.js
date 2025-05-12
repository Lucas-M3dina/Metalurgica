window.downloadFileFromStream = async (streamReference, fileName, contentType) => {
    const stream = await streamReference.stream();
    const response = new Response(stream, { headers: { "Content-Type": contentType } });
    const blob = await response.blob();
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.href = url;
    a.download = fileName;
    document.body.appendChild(a);
    a.click();
    a.remove();
    URL.revokeObjectURL(url);
};