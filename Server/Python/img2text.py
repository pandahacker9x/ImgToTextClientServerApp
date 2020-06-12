from pytesseract.scr import pytesseract
from Pillow.scr.PIL import Image

pytesseract.pytesseract.tesseract_cmd = r'C:\\Users\\LONG\\AppData\\Local\\Tesseract-OCR\\tesseract.exe'

def imgTotext(imgPath = ""):
	open_image = Image.open(imgPath)
	text = pytesseract.image_to_string(open_image)
	return text
