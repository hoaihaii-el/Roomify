from skimage.exposure import rescale_intensity
import cv2 as cv
import numpy as np

def gaussian_kernel(size, sigma=1):
    size = int(size) // 2
    x, y = np.mgrid[-size:size+1, -size:size+1]
    normal = 1 / (2.0 * np.pi * sigma**2)
    g =  np.exp(-((x**2 + y**2) / (2.0*sigma**2))) * normal
    return g

def convolve(image, kernel):
    (iH, iW) = image.shape[:2]
    (kH, kW) = kernel.shape[:2]

    pad = (kW - 1) // 2
    image = cv.copyMakeBorder(image, pad, pad, pad, pad,
        cv.BORDER_REPLICATE)
    output = np.zeros((iH, iW), dtype="float32")

    for y in np.arange(pad, iH + pad):
        for x in np.arange(pad, iW + pad):
            roi = image[y - pad:y + pad + 1, x - pad:x + pad + 1]
            k = (roi * kernel).sum()
            output[y - pad, x - pad] = k

    output = rescale_intensity(output, in_range=(0, 255))
    output = (output * 255).astype("uint8")

    return output

def gaussian_filter(img):
    gaussian = gaussian_kernel(5, 1)
    convoleOutput = convolve(img, gaussian)
    return convoleOutput

imgGray = cv.imread('messi.png', cv.IMREAD_GRAYSCALE)
output = gaussian_filter(imgGray)
cv.imshow('Original', imgGray)
cv.imshow('Gaussian', output)
cv.waitKey(0)
cv.destroyAllWindows()