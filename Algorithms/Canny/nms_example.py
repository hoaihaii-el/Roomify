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

def gradient_calculate(img):
    sobelX = np.array((
        [-1, 0, 1],
        [-2, 0, 2],
        [-1, 0, 1]), dtype="int")
    sobelY = np.array((
        [-1, -2, -1],
        [0, 0, 0],
        [1, 2, 1]), dtype="int")
    Gx = convolve(img, sobelX)
    Gy = convolve(img, sobelY)

    G = np.sqrt((Gx ** 2) + (Gy ** 2))
    G = (G / np.max(G) * 255).astype("uint8")
    theta = np.arctan2(Gy, Gx)

    return (G, theta)

def non_max_suppression(grad, theta):
    M, N = grad.shape
    Z = np.zeros((M,N), dtype=np.int32)
    angle = theta * 180. / np.pi
    angle[angle < 0] += 180
    
    for i in range(1,M-1):
        for j in range(1,N-1):
            try:
                q = 255
                r = 255
                
               #angle 0
                if (0 <= angle[i,j] < 22.5) or (157.5 <= angle[i,j] <= 180):
                    q = grad[i, j+1]
                    r = grad[i, j-1]
                #angle 45
                elif (22.5 <= angle[i,j] < 67.5):
                    q = grad[i+1, j-1]
                    r = grad[i-1, j+1]
                #angle 90
                elif (67.5 <= angle[i,j] < 112.5):
                    q = grad[i+1, j]
                    r = grad[i-1, j]
                #angle 135
                elif (112.5 <= angle[i,j] < 157.5):
                    q = grad[i-1, j-1]
                    r = grad[i+1, j+1]

                if (grad[i,j] >= q) and (grad[i,j] >= r):
                    Z[i,j] = grad[i,j]
                else:
                    Z[i,j] = 0

            except IndexError as e:
                pass
    
    minVal = np.min(Z)
    maxVal = np.max(Z)
    Z = (Z - minVal) / (maxVal - minVal) * 255

    return Z

imgGray = cv.imread('messi2.png', cv.IMREAD_GRAYSCALE)
gaussianOutput = gaussian_filter(imgGray)

G, theta = gradient_calculate(gaussianOutput)
nms = non_max_suppression(G, theta)
cv.imshow('Gradient', G)
cv.imshow('Non Max Suppression', nms)
cv.waitKey(0)
cv.destroyAllWindows()