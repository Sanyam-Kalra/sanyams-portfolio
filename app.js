const prefersReducedMotion = window.matchMedia("(prefers-reduced-motion: reduce)").matches;
const supportsIntersectionObserver = "IntersectionObserver" in window;

const stackContent = {
  experience: {
    title: "Experience layer",
    body: "The first touchpoint should feel fast and stable. I work on clean ingress paths, DNS hygiene, TLS management, and safe traffic routing before requests ever hit the cluster.",
    tags: ["Route 53", "CloudFront", "TLS", "Ingress"],
    note: "Outcome: lower friction for users and fewer surprises for operators."
  },
  compute: {
    title: "Compute layer",
    body: "This is where services need to stay healthy under load. I design around Kubernetes, containers, scaling behavior, and runtime consistency that teams can trust.",
    tags: ["EKS", "Docker", "Autoscaling", "Runtime"],
    note: "Outcome: smoother scaling, cleaner platform ownership, and more predictable production behavior."
  },
  release: {
    title: "Release layer",
    body: "I build delivery paths that reduce fear. CI/CD should validate, promote, and roll back changes cleanly so teams can ship often without creating chaos.",
    tags: ["GitHub Actions", "ArgoCD", "Canary", "Rollback"],
    note: "Outcome: faster shipping with safer deployment decisions."
  },
  signal: {
    title: "Signal layer",
    body: "Metrics, logs, and dashboards should help people decide what to do next. I care about observability that improves incident response instead of overwhelming it.",
    tags: ["Prometheus", "Grafana", "Loki", "Alerts"],
    note: "Outcome: easier debugging, faster recovery, and clearer platform awareness."
  },
  control: {
    title: "Control layer",
    body: "Infrastructure needs to be repeatable and reviewable. Terraform, IAM, secrets, and policy checks help teams grow the platform without losing discipline.",
    tags: ["Terraform", "IAM", "Secrets", "Policy"],
    note: "Outcome: stronger governance and less environment drift."
  }
};

function initThemeToggle() {
  const root = document.documentElement;
  const toggle = document.getElementById("themeToggle");
  const label = document.getElementById("themeToggleLabel");

  if (!toggle || !label) {
    return;
  }

  const stored = window.localStorage.getItem("portfolio-theme");
  const preferredDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
  const initialTheme = stored || (preferredDark ? "dark" : "light");

  const applyTheme = (theme) => {
    root.setAttribute("data-theme", theme);
    label.textContent = theme === "dark" ? "Light Mode" : "Dark Mode";
    window.localStorage.setItem("portfolio-theme", theme);
  };

  applyTheme(initialTheme);

  toggle.addEventListener("click", () => {
    const nextTheme = root.getAttribute("data-theme") === "dark" ? "light" : "dark";
    applyTheme(nextTheme);
  });
}

function initReveal() {
  const items = document.querySelectorAll(".reveal");

  if (prefersReducedMotion || !supportsIntersectionObserver) {
    items.forEach((item) => item.classList.add("is-visible"));
    return;
  }

  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry) => {
        if (entry.isIntersecting) {
          entry.target.classList.add("is-visible");
          observer.unobserve(entry.target);
        }
      });
    },
    { threshold: 0.16 }
  );

  items.forEach((item) => observer.observe(item));
}

function initStackExplorer() {
  const list = document.getElementById("stackList");
  const buttons = list?.querySelectorAll(".stack-item");
  const title = document.getElementById("stackTitle");
  const body = document.getElementById("stackBody");
  const tags = document.getElementById("stackTags");
  const note = document.getElementById("stackNote");
  const story = document.getElementById("stackStory");

  if (!list || !buttons?.length || !title || !body || !tags || !note) {
    return;
  }

  let autoCycle;
  let userInteracted = false;

  const setActive = (key) => {
    const content = stackContent[key];
    if (!content) {
      return;
    }

    buttons.forEach((button) => {
      button.classList.toggle("active", button.dataset.layer === key);
    });

    title.textContent = content.title;
    body.textContent = content.body;
    tags.innerHTML = content.tags.map((tag) => `<span>${tag}</span>`).join("");
    note.textContent = content.note;
  };

  const keys = Object.keys(stackContent);
  const startAutoCycle = () => {
    if (prefersReducedMotion || userInteracted || !story || !("IntersectionObserver" in window)) {
      return;
    }

    let index = 0;
    const observer = new IntersectionObserver(
      (entries) => {
        entries.forEach((entry) => {
          if (!entry.isIntersecting || userInteracted) {
            return;
          }

          clearInterval(autoCycle);
          autoCycle = window.setInterval(() => {
            index = (index + 1) % keys.length;
            setActive(keys[index]);
          }, 2600);
        });
      },
      { threshold: 0.45 }
    );

    observer.observe(story);
  };

  buttons.forEach((button) => {
    const activate = () => {
      userInteracted = true;
      clearInterval(autoCycle);
      setActive(button.dataset.layer);
    };
    button.addEventListener("click", activate);
    button.addEventListener("mouseenter", activate);
    button.addEventListener("focus", activate);
  });

  setActive("experience");
  startAutoCycle();
}

function initHeroMotion() {
  const scene = document.querySelector(".scene-shell");

  if (!scene || prefersReducedMotion) {
    return;
  }

  const canHover = window.matchMedia("(hover: hover) and (pointer: fine)").matches;
  if (!canHover) {
    return;
  }

  const onMove = (event) => {
    const rect = scene.getBoundingClientRect();
    const x = (event.clientX - rect.left) / rect.width - 0.5;
    const y = (event.clientY - rect.top) / rect.height - 0.5;
    scene.style.transform = `rotateX(${y * -5}deg) rotateY(${x * 7}deg)`;
  };

  const reset = () => {
    scene.style.transform = "rotateX(0deg) rotateY(0deg)";
  };

  scene.addEventListener("pointermove", onMove);
  scene.addEventListener("pointerleave", reset);
  reset();
}

function initWorkflowStory() {
  const cards = document.querySelectorAll("#workflowGrid .workflow-card");
  const progressBar = document.getElementById("workflowProgressBar");

  if (!cards.length || !progressBar) {
    return;
  }

  const setActiveStep = (index) => {
    cards.forEach((card, cardIndex) => {
      card.classList.toggle("is-active", cardIndex === index);
    });
    progressBar.style.width = `${((index + 1) / cards.length) * 100}%`;
  };

  if (prefersReducedMotion || !"IntersectionObserver" in window) {
    setActiveStep(0);
    return;
  }

  const observer = new IntersectionObserver(
    (entries) => {
      entries.forEach((entry) => {
        if (!entry.isIntersecting) {
          return;
        }

        const index = [...cards].indexOf(entry.target);
        if (index >= 0) {
          setActiveStep(index);
        }
      });
    },
    { threshold: 0.55 }
  );

  cards.forEach((card) => observer.observe(card));
  setActiveStep(0);
}

function initMouseTracker() {
  const glow = document.getElementById("cursorGlow");
  const dot = document.getElementById("cursorDot");
  const canHover = window.matchMedia("(hover: hover) and (pointer: fine)").matches;

  if (!glow || !dot || prefersReducedMotion || !canHover) {
    return;
  }

  document.body.classList.add("cursor-active");

  let glowX = window.innerWidth / 2;
  let glowY = window.innerHeight / 2;
  let targetX = glowX;
  let targetY = glowY;

  const render = () => {
    glowX += (targetX - glowX) * 0.12;
    glowY += (targetY - glowY) * 0.12;
    glow.style.transform = `translate3d(${glowX}px, ${glowY}px, 0)`;
    dot.style.transform = `translate3d(${targetX}px, ${targetY}px, 0)`;
    window.requestAnimationFrame(render);
  };

  window.addEventListener("pointermove", (event) => {
    targetX = event.clientX;
    targetY = event.clientY;
  });

  render();
}

function initCardSpotlights() {
  const cards = document.querySelectorAll(".impact-card, .recruiter-card, .project-card, .info-card, .crew-card, .workflow-card, .stack-item");
  const canHover = window.matchMedia("(hover: hover) and (pointer: fine)").matches;

  if (!cards.length || prefersReducedMotion || !canHover) {
    return;
  }

  cards.forEach((card) => {
    card.addEventListener("pointermove", (event) => {
      const rect = card.getBoundingClientRect();
      const x = ((event.clientX - rect.left) / rect.width) * 100;
      const y = ((event.clientY - rect.top) / rect.height) * 100;
      card.style.setProperty("--mx", `${x}%`);
      card.style.setProperty("--my", `${y}%`);
    });
  });
}

initThemeToggle();
initReveal();
initStackExplorer();
initHeroMotion();
initWorkflowStory();
initMouseTracker();
initCardSpotlights();
