class PhotoStudioPro {
    constructor() {
        this.video = document.getElementById('videoElement');
        this.canvas = document.getElementById('captureCanvas');
        this.ctx = this.canvas.getContext('2d');
        
        // UI Elements
        this.loadingScreen = document.getElementById('loadingScreen');
        this.mainApp = document.getElementById('mainApp');
        this.captureBtn = document.getElementById('captureBtn');
        this.photoGallery = document.getElementById('photoGallery');
        this.photoCounter = document.getElementById('photoCounter');
        this.createCollageBtn = document.getElementById('createCollageBtn');
        this.collageCanvas = document.getElementById('collageCanvas');
        this.collageResult = document.getElementById('collageResult');
        
        // Timer elements
        this.timerDisplay = document.getElementById('timerDisplay');
        this.timerNumber = document.getElementById('timerNumber');
        this.smilePrompt = document.getElementById('smilePrompt');
        this.flashEffect = document.getElementById('flashEffect');
        
        // Modal elements
        this.settingsModal = document.getElementById('settingsModal');
        this.photoModal = document.getElementById('photoModal');
        this.previewImage = document.getElementById('previewImage');
        
        // Audio elements
        this.shutterSound = document.getElementById('shutterSound');
        this.timerSound = document.getElementById('timerSound');
        
        // App state
        this.photos = [];
        this.currentFilter = 'none';
        this.maxPhotos = 3;
        this.isCapturing = false;
        this.currentStream = null;
        this.facingMode = 'user'; // 'user' for front camera, 'environment' for back camera
        this.currentPhotoIndex = -1;
        
        // Settings
        this.settings = {
            timerDelay: 3,
            soundEnabled: true,
            flashEnabled: true,
            photoQuality: 0.8
        };
        
        this.init();
    }

    async init() {
        try {
            await this.setupCamera();
            this.setupEventListeners();
            this.loadSettings();
            this.hideLoadingScreen();
        } catch (error) {
            console.error('Failed to initialize camera:', error);
            this.showError('Failed to access camera. Please check permissions.');
        }
    }

    async setupCamera() {
        try {
            const constraints = {
                video: {
                    facingMode: this.facingMode,
                    width: { ideal: 1920 },
                    height: { ideal: 1080 }
                }
            };
            
            this.currentStream = await navigator.mediaDevices.getUserMedia(constraints);
            this.video.srcObject = this.currentStream;
            
            return new Promise((resolve) => {
                this.video.onloadedmetadata = () => {
                    resolve();
                };
            });
        } catch (error) {
            throw new Error('Camera access denied or not available');
        }
    }

    setupEventListeners() {
        // Filter buttons
        document.querySelectorAll('.filter-btn').forEach(btn => {
            btn.addEventListener('click', (e) => this.selectFilter(e.target));
        });

        // Capture button
        this.captureBtn.addEventListener('click', () => this.startCapture());

        // Camera controls
        document.getElementById('switchCameraBtn').addEventListener('click', () => this.switchCamera());
        document.getElementById('settingsBtn').addEventListener('click', () => this.openSettings());

        // Gallery controls
        document.getElementById('clearGalleryBtn').addEventListener('click', () => this.clearGallery());
        this.createCollageBtn.addEventListener('click', () => this.createCollage());

        // Collage controls
        document.getElementById('downloadCollageBtn').addEventListener('click', () => this.downloadCollage());
        document.getElementById('shareCollageBtn').addEventListener('click', () => this.shareCollage());

        // Modal controls
        document.getElementById('closeSettingsBtn').addEventListener('click', () => this.closeSettings());
        document.getElementById('closePhotoBtn').addEventListener('click', () => this.closePhotoModal());

        // Settings controls
        document.getElementById('timerSelect').addEventListener('change', (e) => {
            this.settings.timerDelay = parseInt(e.target.value);
            this.saveSettings();
        });

        document.getElementById('soundToggle').addEventListener('change', (e) => {
            this.settings.soundEnabled = e.target.checked;
            this.saveSettings();
        });

        document.getElementById('flashToggle').addEventListener('change', (e) => {
            this.settings.flashEnabled = e.target.checked;
            this.saveSettings();
        });

        document.getElementById('qualitySelect').addEventListener('change', (e) => {
            this.settings.photoQuality = parseFloat(e.target.value);
            this.saveSettings();
        });

        // Photo modal controls
        document.getElementById('downloadPhotoBtn').addEventListener('click', () => this.downloadCurrentPhoto());
        document.getElementById('deletePhotoBtn').addEventListener('click', () => this.deleteCurrentPhoto());

        // Keyboard shortcuts
        document.addEventListener('keydown', (e) => {
            if (e.code === 'Space' && !this.isCapturing) {
                e.preventDefault();
                this.startCapture();
            }
        });
    }

    hideLoadingScreen() {
        setTimeout(() => {
            this.loadingScreen.classList.add('hidden');
            this.mainApp.classList.remove('hidden');
        }, 2000);
    }

    selectFilter(button) {
        // Remove active class from all filter buttons
        document.querySelectorAll('.filter-btn').forEach(btn => btn.classList.remove('active'));
        
        // Add active class to clicked button
        button.classList.add('active');
        
        // Apply filter
        this.currentFilter = button.dataset.filter;
        this.applyFilter();
        
        // Play sound effect
        this.playSound('click');
    }

    applyFilter() {
        this.video.className = `filter-${this.currentFilter}`;
    }

    async startCapture() {
        if (this.isCapturing || this.photos.length >= this.maxPhotos) return;
        
        this.isCapturing = true;
        this.captureBtn.disabled = true;
        
        if (this.settings.timerDelay > 0) {
            await this.startTimer();
        }
        
        this.showSmilePrompt();
        await this.capturePhoto();
        
        this.isCapturing = false;
        this.captureBtn.disabled = false;
    }

    async startTimer() {
        this.timerDisplay.classList.remove('hidden');
        
        for (let i = this.settings.timerDelay; i > 0; i--) {
            this.timerNumber.textContent = i;
            this.playSound('timer');
            await this.delay(1000);
        }
        
        this.timerDisplay.classList.add('hidden');
    }

    showSmilePrompt() {
        this.smilePrompt.classList.remove('hidden');
        setTimeout(() => {
            this.smilePrompt.classList.add('hidden');
        }, 2000);
    }

    async capturePhoto() {
        // Setup canvas
        this.canvas.width = this.video.videoWidth;
        this.canvas.height = this.video.videoHeight;
        
        // Apply filter to canvas context
        this.ctx.filter = this.getFilterCSS();
        
        // Draw video frame to canvas
        this.ctx.drawImage(this.video, 0, 0);
        
        // Flash effect
        if (this.settings.flashEnabled) {
            this.flashEffect.classList.add('active');
            setTimeout(() => {
                this.flashEffect.classList.remove('active');
            }, 300);
        }
        
        // Play shutter sound
        this.playSound('shutter');
        
        // Get image data
        const imageData = this.canvas.toDataURL('image/jpeg', this.settings.photoQuality);
        
        // Create photo object
        const photo = {
            id: Date.now(),
            data: imageData,
            filter: this.currentFilter,
            timestamp: new Date().toLocaleString(),
            date: new Date()
        };
        
        // Add to photos array
        this.photos.push(photo);
        
        // Update UI
        this.updatePhotoCounter();
        this.displayPhotos();
        this.updateCollageButton();
        
        // Show success animation
        this.showCaptureSuccess();
    }

    getFilterCSS() {
        const filters = {
            'none': 'none',
            'grayscale': 'grayscale(100%)',
            'sepia': 'sepia(100%)',
            'vintage': 'sepia(50%) contrast(120%) brightness(110%) saturate(80%)',
            'cool': 'hue-rotate(180deg) saturate(120%) brightness(110%)',
            'warm': 'hue-rotate(30deg) saturate(130%) brightness(110%)',
            'dramatic': 'contrast(150%) brightness(90%) saturate(120%)',
            'neon': 'hue-rotate(270deg) saturate(200%) brightness(120%) contrast(120%)'
        };
        return filters[this.currentFilter] || 'none';
    }

    showCaptureSuccess() {
        // Add a subtle animation to indicate successful capture
        this.captureBtn.style.transform = 'scale(0.9)';
        setTimeout(() => {
            this.captureBtn.style.transform = 'scale(1)';
        }, 150);
    }

    updatePhotoCounter() {
        this.photoCounter.textContent = `${this.photos.length}/${this.maxPhotos}`;
    }

    displayPhotos() {
        if (this.photos.length === 0) {
            this.photoGallery.innerHTML = `
                <div class="empty-gallery">
                    <i class="fas fa-camera"></i>
                    <p>No photos yet</p>
                    <span>Start capturing memories!</span>
                </div>
            `;
            return;
        }

        this.photoGallery.innerHTML = this.photos.map((photo, index) => `
            <div class="photo-item" onclick="photoStudio.openPhotoModal(${index})">
                <img src="${photo.data}" alt="Photo ${index + 1}">
                <div class="photo-info">
                    <div class="photo-meta">
                        <span>${photo.timestamp}</span>
                        <span class="filter-tag">${photo.filter}</span>
                    </div>
                </div>
            </div>
        `).join('');
    }

    updateCollageButton() {
        if (this.photos.length >= 3) {
            this.createCollageBtn.classList.remove('disabled');
            this.createCollageBtn.innerHTML = `
                <i class="fas fa-magic"></i>
                <span>Create Amazing Collage!</span>
            `;
        } else {
            this.createCollageBtn.classList.add('disabled');
            this.createCollageBtn.innerHTML = `
                <i class="fas fa-magic"></i>
                <span>Create Collage</span>
                <small>(Need ${3 - this.photos.length} more photos)</small>
            `;
        }
    }

    async switchCamera() {
        try {
            // Stop current stream
            if (this.currentStream) {
                this.currentStream.getTracks().forEach(track => track.stop());
            }
            
            // Switch facing mode
            this.facingMode = this.facingMode === 'user' ? 'environment' : 'user';
            
            // Setup new camera
            await this.setupCamera();
            this.applyFilter();
            
            this.playSound('click');
        } catch (error) {
            console.error('Failed to switch camera:', error);
            this.showError('Failed to switch camera');
        }
    }

    openSettings() {
        this.settingsModal.classList.remove('hidden');
        
        // Update settings UI
        document.getElementById('timerSelect').value = this.settings.timerDelay;
        document.getElementById('soundToggle').checked = this.settings.soundEnabled;
        document.getElementById('flashToggle').checked = this.settings.flashEnabled;
        document.getElementById('qualitySelect').value = this.settings.photoQuality;
    }

    closeSettings() {
        this.settingsModal.classList.add('hidden');
    }

    openPhotoModal(index) {
        this.currentPhotoIndex = index;
        const photo = this.photos[index];
        
        this.previewImage.src = photo.data;
        this.photoModal.classList.remove('hidden');
    }

    closePhotoModal() {
        this.photoModal.classList.add('hidden');
        this.currentPhotoIndex = -1;
    }

    downloadCurrentPhoto() {
        if (this.currentPhotoIndex >= 0) {
            const photo = this.photos[this.currentPhotoIndex];
            this.downloadImage(photo.data, `photo-${photo.id}.jpg`);
        }
    }

    deleteCurrentPhoto() {
        if (this.currentPhotoIndex >= 0) {
            this.photos.splice(this.currentPhotoIndex, 1);
            this.displayPhotos();
            this.updatePhotoCounter();
            this.updateCollageButton();
            this.closePhotoModal();
            
            // Re-enable capture button if we're below max photos
            if (this.photos.length < this.maxPhotos) {
                this.captureBtn.disabled = false;
                this.captureBtn.innerHTML = `
                    <div class="capture-inner">
                        <i class="fas fa-camera"></i>
                    </div>
                `;
            }
        }
    }

    clearGallery() {
        if (this.photos.length === 0) return;
        
        if (confirm('Are you sure you want to delete all photos?')) {
            this.photos = [];
            this.displayPhotos();
            this.updatePhotoCounter();
            this.updateCollageButton();
            this.collageResult.classList.add('hidden');
            
            // Re-enable capture button
            this.captureBtn.disabled = false;
            this.captureBtn.innerHTML = `
                <div class="capture-inner">
                    <i class="fas fa-camera"></i>
                </div>
            `;
        }
    }

    async createCollage() {
        if (this.photos.length < 3) return;
        
        const canvas = this.collageCanvas;
        const ctx = canvas.getContext('2d');
        
        // Set canvas size
        canvas.width = 1200;
        canvas.height = 800;
        
        // Create gradient background
        const gradient = ctx.createLinearGradient(0, 0, canvas.width, canvas.height);
        gradient.addColorStop(0, '#667eea');
        gradient.addColorStop(0.5, '#764ba2');
        gradient.addColorStop(1, '#f093fb');
        ctx.fillStyle = gradient;
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        
        // Add decorative elements
        this.addCollageDecorations(ctx, canvas.width, canvas.height);
        
        // Load and position photos
        const photoPromises = this.photos.slice(0, 3).map((photo, index) => {
            return new Promise((resolve) => {
                const img = new Image();
                img.crossOrigin = 'anonymous';
                img.onload = () => {
                    const positions = this.getCollagePositions(canvas.width, canvas.height);
                    const pos = positions[index];
                    
                    // Add shadow
                    ctx.shadowColor = 'rgba(0, 0, 0, 0.3)';
                    ctx.shadowBlur = 20;
                    ctx.shadowOffsetX = 5;
                    ctx.shadowOffsetY = 5;
                    
                    // Add white border
                    ctx.fillStyle = 'white';
                    ctx.fillRect(pos.x - 15, pos.y - 15, pos.width + 30, pos.height + 30);
                    
                    // Reset shadow
                    ctx.shadowColor = 'transparent';
                    
                    // Draw photo
                    ctx.drawImage(img, pos.x, pos.y, pos.width, pos.height);
                    
                    // Add photo number
                    ctx.fillStyle = 'white';
                    ctx.font = 'bold 24px Poppins';
                    ctx.textAlign = 'center';
                    ctx.strokeStyle = 'rgba(0, 0, 0, 0.5)';
                    ctx.lineWidth = 2;
                    ctx.strokeText(`${index + 1}`, pos.x + pos.width/2, pos.y + pos.height + 50);
                    ctx.fillText(`${index + 1}`, pos.x + pos.width/2, pos.y + pos.height + 50);
                    
                    resolve();
                };
                img.src = photo.data;
            });
        });
        
        await Promise.all(photoPromises);
        
        // Add title and date
        this.addCollageText(ctx, canvas.width, canvas.height);
        
        // Show result
        this.collageResult.classList.remove('hidden');
        this.collageResult.scrollIntoView({ behavior: 'smooth' });
        
        this.playSound('success');
    }

    getCollagePositions(canvasWidth, canvasHeight) {
        return [
            { x: 100, y: 150, width: 350, height: 500 }, // Large left photo
            { x: 550, y: 150, width: 300, height: 200 }, // Top right photo
            { x: 550, y: 450, width: 300, height: 200 }  // Bottom right photo
        ];
    }

    addCollageDecorations(ctx, width, height) {
        // Add some decorative circles
        ctx.globalAlpha = 0.1;
        ctx.fillStyle = 'white';
        
        // Large circles
        ctx.beginPath();
        ctx.arc(width * 0.8, height * 0.2, 100, 0, Math.PI * 2);
        ctx.fill();
        
        ctx.beginPath();
        ctx.arc(width * 0.2, height * 0.8, 80, 0, Math.PI * 2);
        ctx.fill();
        
        ctx.globalAlpha = 1;
    }

    addCollageText(ctx, width, height) {
        // Add title
        ctx.fillStyle = 'white';
        ctx.font = 'bold 48px Poppins';
        ctx.textAlign = 'center';
        ctx.strokeStyle = 'rgba(0, 0, 0, 0.3)';
        ctx.lineWidth = 3;
        ctx.strokeText('My Photo Memories', width / 2, 80);
        ctx.fillText('My Photo Memories', width / 2, 80);
        
        // Add date
        ctx.font = '24px Poppins';
        const date = new Date().toLocaleDateString('en-US', { 
            year: 'numeric', 
            month: 'long', 
            day: 'numeric' 
        });
        ctx.strokeText(date, width / 2, height - 40);
        ctx.fillText(date, width / 2, height - 40);
        
        // Add app watermark
        ctx.font = '18px Poppins';
        ctx.fillStyle = 'rgba(255, 255, 255, 0.7)';
        ctx.textAlign = 'right';
        ctx.fillText('Created with PhotoStudio Pro', width - 50, height - 20);
    }

    downloadCollage() {
        this.downloadImage(this.collageCanvas.toDataURL('image/jpeg', 0.9), `collage-${Date.now()}.jpg`);
    }

    async shareCollage() {
        if (navigator.share) {
            try {
                const canvas = this.collageCanvas;
                canvas.toBlob(async (blob) => {
                    const file = new File([blob], 'my-collage.jpg', { type: 'image/jpeg' });
                    await navigator.share({
                        title: 'My Photo Collage',
                        text: 'Check out my amazing photo collage!',
                        files: [file]
                    });
                });
            } catch (error) {
                console.error('Error sharing:', error);
                this.downloadCollage(); // Fallback to download
            }
        } else {
            this.downloadCollage(); // Fallback to download
        }
    }

    downloadImage(dataUrl, filename) {
        const link = document.createElement('a');
        link.download = filename;
        link.href = dataUrl;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }

    playSound(type) {
        if (!this.settings.soundEnabled) return;
        
        try {
            if (type === 'shutter') {
                this.shutterSound.currentTime = 0;
                this.shutterSound.play();
            } else if (type === 'timer') {
                this.timerSound.currentTime = 0;
                this.timerSound.play();
            }
        } catch (error) {
            console.error('Error playing sound:', error);
        }
    }

    loadSettings() {
        const saved = localStorage.getItem('photoStudioSettings');
        if (saved) {
            this.settings = { ...this.settings, ...JSON.parse(saved) };
        }
    }

    saveSettings() {
        localStorage.setItem('photoStudioSettings', JSON.stringify(this.settings));
    }

    showError(message) {
        // Create and show error notification
        const errorDiv = document.createElement('div');
        errorDiv.className = 'error-notification';
        errorDiv.innerHTML = `
            <i class="fas fa-exclamation-triangle"></i>
            <span>${message}</span>
        `;
        errorDiv.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            background: #ef4444;
            color: white;
            padding: 1rem 1.5rem;
            border-radius: 12px;
            box-shadow: 0 4px 20px rgba(0, 0, 0, 0.2);
            z-index: 10000;
            display: flex;
            align-items: center;
            gap: 0.5rem;
            font-weight: 500;
        `;
        
        document.body.appendChild(errorDiv);
        
        setTimeout(() => {
            errorDiv.remove();
        }, 5000);
    }

    delay(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
}

// Initialize the app
let photoStudio;
document.addEventListener('DOMContentLoaded', () => {
    photoStudio = new PhotoStudioPro();
});

// Handle page visibility changes
document.addEventListener('visibilitychange', () => {
    if (document.hidden && photoStudio && photoStudio.currentStream) {
        // Pause camera when page is hidden to save resources
        photoStudio.video.pause();
    } else if (!document.hidden && photoStudio && photoStudio.currentStream) {
        // Resume camera when page is visible
        photoStudio.video.play();
    }
});