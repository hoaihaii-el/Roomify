import numpy as np
import matplotlib.pyplot as plt

def ransac(data, n, k, t, d):
    # n = 2 (the number of points needed to create a line)
    # k: the number of iterations
    # t: threshold for inliers (distance from a point to a line)
    # d: the number of inliers to assert that a model is good

    best_line = None
    best_inliers = None

    for _ in range(k):
        sample_indices = np.random.choice(data.shape[1], n, replace=False)
        sample = data[:, sample_indices]

        x1, y1 = sample[:, 0]
        x2, y2 = sample[:, 1]
        a = y2 - y1
        b = x1 - x2
        c = -a * x1 - b * y1

        distances = np.abs(a * data[0, :] + b * data[1, :] + c) / np.sqrt(a**2 + b**2)
        inliers = np.where(distances < t)[0]

        if len(inliers) >= d:
            if best_line is None or len(inliers) > len(best_inliers):
                best_line = (a, b, c)
                best_inliers = inliers

    return best_line, best_inliers

np.random.seed(0)
data = np.concatenate([
    np.random.normal(loc=[i, 2*i], scale=1, size=(2, 50)) for i in range(5)
], axis=1)

data += np.random.normal(loc=0, scale=5, size=data.shape)

best_line, best_inliers = ransac(data, n=2, k=100, t=2, d=30)

plt.figure(figsize=(8, 6))
plt.scatter(data[0, :], data[1, :], label='Data points')

if best_line is not None:
    a, b, c = best_line
    x_vals = np.linspace(data[0, :].min(), data[0, :].max(), 100)
    y_vals = -(a * x_vals + c) / b
    plt.plot(x_vals, y_vals, color='red', label='RANSAC line')
    plt.scatter(data[0, best_inliers], data[1, best_inliers], color='green', label='Inliers')

plt.legend()
plt.title('RANSAC')
plt.xlabel('x')
plt.ylabel('y')
plt.grid(True)
plt.show()