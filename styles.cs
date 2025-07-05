/* Reset and Base Styles */
* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

body {
    font-family: 'Poppins', sans-serif;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    min-height: 100vh;
    overflow-x: hidden;
}

.hidden {
    display: none !important;
}

/* Loading Screen */
.loading-screen {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 9999;
}

.loading-content {
    text-align: center;
    color: white;
}

.camera-icon {
    font-size: 4rem;
    margin-bottom: 1rem;
    animation: pulse 2s infinite;
}

.loading-content h2 {
    font-size: 2rem;
    font-weight: 600;
    margin-bottom: 2rem;
}

.loading-spinner {
    width: 50px;
    height: 50px;
    border: 4px solid rgba(255, 255, 255, 0.3);
    border-top: 4px solid white;
    border-radius: 50%;
    animation: spin 1s linear infinite;
    margin: 0 auto 1rem;
}

.loading-content p {
    font-size: 1.1rem;
    opacity: 0.9;
}

@keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
}

@keyframes pulse {
    0%, 100% { transform: scale(1); }
    50% { transform: scale(1.1); }
}

/* Main App */
.main-app {
    min-height: 100vh;
    background: #f8fafc;
}

/* Header */
.app-header {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
    padding: 1rem 0;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.header-content {
    max-width: 1200px;
    margin: 0 auto;
    padding: 0 2rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
}

.logo {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-size: 1.5rem;
    font-weight: 600;
}

.logo i {
    font-size: 2rem;
}

.header-stats {
    display: flex;
    gap: 2rem;
}

.stat-item {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    font-weight: 500;
    background: rgba(255, 255, 255, 0.1);
    padding: 0.5rem 1rem;
    border-radius: 20px;
    backdrop-filter: blur(10px);
}

/* Camera Section */
.camera-section {
    max-width: 1200px;
    margin: 0 auto;
    padding: 2rem;
}

.camera-container {
    background: white;
    border-radius: 20px;
    box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
    overflow: hidden;
}

/* Video Wrapper */
.video-wrapper {
    position: relative;
    background: #000;
    aspect-ratio: 16/9;
    overflow: hidden;
}

#videoElement {
    width: 100%;
    height: 100%;
    object-fit: cover;
    transition: filter 0.3s ease;
}

.camera-overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    pointer-events: none;
}

/* Grid Lines */
.grid-lines {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    opacity: 0.3;
}

.grid-line {
    position: absolute;
    background: rgba(255, 255, 255, 0.5);
}

.grid-line.vertical {
    width: 1px;
    height: 100%;
    top: 0;
}

.grid-line.vertical:nth-child(1) {
    left: 33.33%;
}

.grid-line.vertical:nth-child(2) {
    left: 66.66%;
}

.grid-line.horizontal {
    width: 100%;
    height: 1px;
    left: 0;
}

.grid-line.horizontal:nth-child(3) {
    top: 33.33%;
}

.grid-line.horizontal:nth-child(4) {
    top: 66.66%;
}

/* Timer Display */
.timer-display {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    z-index: 10;
}

.timer-circle {
    width: 120px;
    height: 120px;
    border: 4px solid rgba(255, 255, 255, 0.8);
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    background: rgba(0, 0, 0, 0.5);
    animation: timerPulse 1s ease-in-out;
    backdrop-filter: blur(10px);
}

.timer-circle span {
    font-size: 3rem;
    font-weight: bold;
    color: white;
}

@keyframes timerPulse {
    0% { transform: scale(0.8); opacity: 0; }
    50% { transform: scale(1.1); opacity: 1; }
    100% { transform: scale(1); opacity: 1; }
}

/* Smile Prompt */
.smile-prompt {
    position: absolute;
    bottom: 2rem;
    left: 50%;
    transform: translateX(-50%);
    background: rgba(0, 0, 0, 0.8);
    color: white;
    padding: 1.5rem 2rem;
    border-radius: 20px;
    animation: slideUp 0.5s ease-out;
    backdrop-filter: blur(10px);
    text-align: center;
}

.smile-content {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
}

.smile-content i {
    font-size: 2rem;
    color: #ffd700;
    margin-bottom: 0.5rem;
}

.smile-content p {
    font-size: 1.2rem;
    font-weight: 600;
    margin-bottom: 0.25rem;
}

.smile-content span {
    font-size: 0.9rem;
    opacity: 0.8;
}

@keyframes slideUp {
    from { transform: translate(-50%, 100%); opacity: 0; }
    to { transform: translate(-50%, 0); opacity: 1; }
}

/* Flash Effect */
.flash-effect {
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: white;
    opacity: 0;
    pointer-events: none;
}

.flash-effect.active {
    animation: flash 0.3s ease-out;
}

@keyframes flash {
    0% { opacity: 0; }
    50% { opacity: 0.8; }
    100% { opacity: 0; }
}

/* Filter Section */
.filter-section {
    padding: 2rem;
    border-bottom: 1px solid #e2e8f0;
    background: linear-gradient(135deg, #f8fafc 0%, #e2e8f0 100%);
}

.filter-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 1.5rem;
}

.filter-header h3 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
    font-size: 1.2rem;
}

.filter-info {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #64748b;
    font-size: 0.9rem;
}

.filter-grid {
    display: grid;
    grid-template-columns: repeat(auto-fit, minmax(100px, 1fr));
    gap: 1rem;
}

.filter-btn {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.75rem;
    padding: 1.5rem 1rem;
    border: 2px solid transparent;
    border-radius: 16px;
    background: white;
    cursor: pointer;
    transition: all 0.3s ease;
    font-size: 0.85rem;
    font-weight: 500;
    color: #64748b;
    position: relative;
    overflow: hidden;
}

.filter-btn::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    opacity: 0;
    transition: opacity 0.3s ease;
    z-index: 0;
}

.filter-btn > * {
    position: relative;
    z-index: 1;
}

.filter-btn:hover {
    transform: translateY(-4px);
    box-shadow: 0 8px 25px rgba(0, 0, 0, 0.15);
}

.filter-btn.active::before {
    opacity: 1;
}

.filter-btn.active {
    color: white;
    border-color: #667eea;
}

.filter-icon {
    font-size: 1.5rem;
    margin-bottom: 0.5rem;
    opacity: 0.8;
}

.filter-btn.active .filter-icon {
    opacity: 1;
}

.filter-preview {
    width: 50px;
    height: 50px;
    border-radius: 12px;
    background: linear-gradient(45deg, #ff6b6b, #4ecdc4, #45b7d1, #96ceb4);
    background-size: 200% 200%;
    animation: gradientShift 3s ease infinite;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
}

@keyframes gradientShift {
    0% { background-position: 0% 50%; }
    50% { background-position: 100% 50%; }
    100% { background-position: 0% 50%; }
}

/* Filter Effects */
.filter-none { filter: none; }
.filter-grayscale { filter: grayscale(100%); }
.filter-sepia { filter: sepia(100%); }
.filter-vintage { filter: sepia(50%) contrast(120%) brightness(110%) saturate(80%); }
.filter-cool { filter: hue-rotate(180deg) saturate(120%) brightness(110%); }
.filter-warm { filter: hue-rotate(30deg) saturate(130%) brightness(110%); }
.filter-dramatic { filter: contrast(150%) brightness(90%) saturate(120%); }
.filter-neon { filter: hue-rotate(270deg) saturate(200%) brightness(120%) contrast(120%); }

/* Camera Controls */
.camera-controls {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 3rem;
    padding: 2.5rem;
    background: linear-gradient(135deg, #f8fafc 0%, #e2e8f0 100%);
}

.control-btn {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
    padding: 1.25rem;
    border: none;
    border-radius: 16px;
    background: white;
    color: #64748b;
    cursor: pointer;
    transition: all 0.3s ease;
    font-size: 0.9rem;
    font-weight: 500;
    box-shadow: 0 4px 15px rgba(0, 0, 0, 0.05);
}

.control-btn:hover {
    background: #667eea;
    color: white;
    transform: translateY(-3px);
    box-shadow: 0 8px 25px rgba(102, 126, 234, 0.3);
}

.control-btn i {
    font-size: 1.5rem;
}

.capture-btn {
    width: 90px;
    height: 90px;
    border: none;
    border-radius: 50%;
    background: white;
    cursor: pointer;
    transition: all 0.3s ease;
    position: relative;
    box-shadow: 0 8px 30px rgba(0, 0, 0, 0.15);
}

.capture-btn:hover {
    transform: scale(1.1);
    box-shadow: 0 12px 40px rgba(102, 126, 234, 0.4);
}

.capture-btn:active {
    transform: scale(0.95);
}

.capture-inner {
    width: 70px;
    height: 70px;
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    border-radius: 50%;
    display: flex;
    align-items: center;
    justify-content: center;
    color: white;
    font-size: 1.8rem;
    margin: 10px;
    position: relative;
    z-index: 2;
}

.capture-ring {
    position: absolute;
    top: 5px;
    left: 5px;
    right: 5px;
    bottom: 5px;
    border: 3px solid #667eea;
    border-radius: 50%;
    z-index: 1;
}

.capture-btn:disabled {
    opacity: 0.5;
    cursor: not-allowed;
    transform: none;
}

/* Gallery Section */
.gallery-section {
    max-width: 1200px;
    margin: 0 auto;
    padding: 2rem;
}

.gallery-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 2rem;
}

.gallery-header h2 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
    font-size: 1.8rem;
}

.gallery-actions {
    display: flex;
    gap: 1rem;
}

.photo-grid {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(280px, 1fr));
    gap: 2rem;
    margin-bottom: 3rem;
}

.empty-gallery {
    grid-column: 1 / -1;
    text-align: center;
    padding: 4rem 2rem;
    background: white;
    border-radius: 20px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.05);
}

.empty-icon {
    font-size: 5rem;
    color: #cbd5e1;
    margin-bottom: 1.5rem;
}

.empty-gallery h3 {
    font-size: 1.5rem;
    color: #334155;
    margin-bottom: 0.5rem;
    font-weight: 600;
}

.empty-gallery p {
    color: #64748b;
    margin-bottom: 2rem;
    font-size: 1.1rem;
}

.empty-features {
    display: flex;
    justify-content: center;
    gap: 2rem;
    flex-wrap: wrap;
}

.feature-item {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
    color: #64748b;
    font-size: 0.9rem;
}

.feature-item i {
    font-size: 1.5rem;
    color: #667eea;
}

.photo-item {
    background: white;
    border-radius: 20px;
    overflow: hidden;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
    cursor: pointer;
}

.photo-item:hover {
    transform: translateY(-8px);
    box-shadow: 0 12px 40px rgba(0, 0, 0, 0.2);
}

.photo-item img {
    width: 100%;
    height: 220px;
    object-fit: cover;
}

.photo-info {
    padding: 1.5rem;
}

.photo-meta {
    display: flex;
    justify-content: space-between;
    align-items: center;
    font-size: 0.9rem;
    color: #64748b;
}

.filter-tag {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
    padding: 0.4rem 1rem;
    border-radius: 20px;
    font-size: 0.8rem;
    font-weight: 500;
}

/* Buttons */
.btn-primary, .btn-secondary, .btn-danger, .btn-outline {
    display: inline-flex;
    align-items: center;
    gap: 0.5rem;
    padding: 0.875rem 1.75rem;
    border: none;
    border-radius: 12px;
    font-weight: 500;
    cursor: pointer;
    transition: all 0.3s ease;
    text-decoration: none;
    font-size: 0.95rem;
}

.btn-primary {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
    color: white;
}

.btn-primary:hover {
    transform: translateY(-2px);
    box-shadow: 0 6px 20px rgba(102, 126, 234, 0.4);
}

.btn-secondary {
    background: #f1f5f9;
    color: #64748b;
}

.btn-secondary:hover {
    background: #e2e8f0;
    transform: translateY(-2px);
}

.btn-outline {
    background: transparent;
    color: #667eea;
    border: 2px solid #667eea;
}

.btn-outline:hover {
    background: #667eea;
    color: white;
    transform: translateY(-2px);
}

.btn-danger {
    background: #ef4444;
    color: white;
}

.btn-danger:hover {
    background: #dc2626;
    transform: translateY(-2px);
}

.btn-primary.disabled {
    background: #cbd5e1;
    color: #94a3b8;
    cursor: not-allowed;
    transform: none;
}

.btn-primary.disabled:hover {
    transform: none;
    box-shadow: none;
}

/* Collage Section */
.collage-section {
    text-align: center;
    padding: 3rem 2rem;
    background: white;
    border-radius: 20px;
    box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.collage-header {
    margin-bottom: 2rem;
}

.collage-header h3 {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
    font-size: 1.5rem;
    margin-bottom: 0.5rem;
}

.collage-header p {
    color: #64748b;
    font-size: 1.1rem;
}

.collage-title {
    margin-bottom: 2rem;
}

.collage-title h3 {
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
    font-size: 1.8rem;
    margin-bottom: 0.5rem;
}

.collage-title p {
    color: #64748b;
    font-size: 1.1rem;
}

.collage-container {
    margin-bottom: 2rem;
}

#collageCanvas {
    max-width: 100%;
    border-radius: 16px;
    box-shadow: 0 12px 40px rgba(0, 0, 0, 0.2);
}

.collage-actions {
    display: flex;
    justify-content: center;
    gap: 1rem;
    flex-wrap: wrap;
}

/* Modal Styles */
.modal {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.8);
    display: flex;
    align-items: center;
    justify-content: center;
    z-index: 1000;
    backdrop-filter: blur(8px);
}

.modal-content {
    background: white;
    border-radius: 20px;
    max-width: 500px;
    width: 90%;
    max-height: 90vh;
    overflow-y: auto;
    box-shadow: 0 20px 60px rgba(0, 0, 0, 0.3);
}

.photo-modal .modal-content {
    max-width: 900px;
}

.modal-header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1.5rem;
    border-bottom: 1px solid #e2e8f0;
}

.modal-header h3 {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    color: #334155;
    font-weight: 600;
}

.close-btn {
    width: 40px;
    height: 40px;
    border: none;
    border-radius: 50%;
    background: #f1f5f9;
    color: #64748b;
    cursor: pointer;
    transition: all 0.3s ease;
}

.close-btn:hover {
    background: #e2e8f0;
    transform: scale(1.1);
}

.modal-body {
    padding: 1.5rem;
}

/* Settings */
.setting-group {
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 1.25rem 0;
    border-bottom: 1px solid #f1f5f9;
}

.setting-group:last-child {
    border-bottom: none;
}

.setting-group label {
    display: flex;
    align-items: center;
    gap: 0.75rem;
    font-weight: 500;
    color: #334155;
    font-size: 1rem;
}

.setting-group select {
    padding: 0.75rem;
    border: 1px solid #d1d5db;
    border-radius: 8px;
    background: white;
    color: #374151;
    font-size: 0.95rem;
}

/* Toggle Switch */
.toggle-switch {
    position: relative;
    width: 60px;
    height: 30px;
}

.toggle-switch input {
    opacity: 0;
    width: 0;
    height: 0;
}

.slider {
    position: absolute;
    cursor: pointer;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background-color: #cbd5e1;
    transition: 0.3s;
    border-radius: 30px;
}

.slider:before {
    position: absolute;
    content: "";
    height: 22px;
    width: 22px;
    left: 4px;
    bottom: 4px;
    background-color: white;
    transition: 0.3s;
    border-radius: 50%;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.2);
}

input:checked + .slider {
    background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
}

input:checked + .slider:before {
    transform: translateX(30px);
}

/* Photo Preview */
.photo-preview-container {
    margin-bottom: 1.5rem;
}

#previewImage {
    width: 100%;
    border-radius: 12px;
    margin-bottom: 1rem;
}

.photo-details {
    display: flex;
    justify-content: space-around;
    padding: 1rem;
    background: #f8fafc;
    border-radius: 12px;
}

.detail-item {
    display: flex;
    flex-direction: column;
    align-items: center;
    gap: 0.5rem;
    color: #64748b;
    font-size: 0.9rem;
}

.detail-item i {
    font-size: 1.2rem;
    color: #667eea;
}

/* Photo Actions */
.photo-actions {
    display: flex;
    justify-content: center;
    gap: 1rem;
    margin-top: 1.5rem;
}

/* Responsive Design */
@media (max-width: 768px) {
    .header-content {
        padding: 0 1rem;
    }
    
    .header-stats {
        gap: 1rem;
    }
    
    .stat-item {
        padding: 0.4rem 0.8rem;
        font-size: 0.9rem;
    }
    
    .camera-section,
    .gallery-section {
        padding: 1rem;
    }
    
    .filter-grid {
        grid-template-columns: repeat(4, 1fr);
        gap: 0.75rem;
    }
    
    .filter-btn {
        padding: 1rem 0.5rem;
        gap: 0.5rem;
    }
    
    .filter-preview {
        width: 40px;
        height: 40px;
    }
    
    .camera-controls {
        gap: 1.5rem;
        padding: 2rem;
    }
    
    .capture-btn {
        width: 80px;
        height: 80px;
    }
    
    .capture-inner {
        width: 60px;
        height: 60px;
        margin: 10px;
        font-size: 1.5rem;
    }
    
    .photo-grid {
        grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
        gap: 1.5rem;
    }
    
    .gallery-header {
        flex-direction: column;
        gap: 1rem;
        align-items: stretch;
    }
    
    .collage-actions {
        flex-direction: column;
        align-items: center;
    }
    
    .modal-content {
        margin: 1rem;
        width: calc(100% - 2rem);
    }
    
    .empty-features {
        flex-direction: column;
        gap: 1rem;
    }
    
    .photo-details {
        flex-direction: column;
        gap: 1rem;
    }
    
    .detail-item {
        flex-direction: row;
        justify-content: center;
    }
}

@media (max-width: 480px) {
    .logo span {
        display: none;
    }
    
    .filter-grid {
        grid-template-columns: repeat(3, 1fr);
    }
    
    .camera-controls {
        flex-direction: column;
        gap: 2rem;
    }
    
    .control-btn {
        flex-direction: row;
        padding: 1rem 1.5rem;
    }
    
    .collage-section {
        padding: 2rem 1rem;
    }
    
    .photo-actions {
        flex-direction: column;
    }
}

/* Additional Professional Touches */
.filter-btn:hover .filter-preview {
    transform: scale(1.1);
}

.photo-item::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: linear-gradient(135deg, rgba(102, 126, 234, 0.1) 0%, rgba(118, 75, 162, 0.1) 100%);
    opacity: 0;
    transition: opacity 0.3s ease;
    z-index: 1;
}

.photo-item:hover::before {
    opacity: 1;
}

.photo-item > * {
    position: relative;
    z-index: 2;
}

/* Smooth transitions for all interactive elements */
button, .filter-btn, .photo-item, .modal-content {
    transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
}

/* Enhanced focus states for accessibility */
button:focus, .filter-btn:focus {
    outline: 2px solid #667eea;
    outline-offset: 2px;
}