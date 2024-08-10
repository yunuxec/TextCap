# TextCap
TextCap is a .NET 8 application that enables users to capture full screenshots of their desktop, select a region of interest (ROI) from the screenshot, and extract text from that region using Tesseract OCR. The extracted text is then saved to a timestamped .txt file in an output folder. The application features options to open the output folder and view the saved files. Designed to be simple and user-friendly, TextCap makes it easy to capture and process screen content for various uses.

# Tesseract OCR
## Data Files
- To use Tesseract OCR, you need language data files in `.traineddata` format.
- Obtain the Tesseract data files from the [Tesseract GitHub repository](https://github.com/tesseract-ocr/tessdata) or from the [official Tesseract website](https://tesseract-ocr.github.io/tessdata/).

## Installation
- Download the language data files you need and place them in the `tessdata` directory of your TextCap project.
- The default path for `tessdata` is typically `C:\Users\[YourUsername]\source\repos\TextCap\TextCap\tessdata`, but make sure this path matches your project configuration.

## Configuration
- Ensure the `tessdata` directory path is correctly set in your project settings or code to enable Tesseract to locate the language files.

## Notes
- Keep the Tesseract data files updated for better OCR accuracy.
- Consult the Tesseract [documentation](https://tesseract-ocr.github.io/tessdoc/) for more details on configuration and language support.
